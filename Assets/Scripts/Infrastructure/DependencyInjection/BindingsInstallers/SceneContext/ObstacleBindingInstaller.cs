﻿using BlockBreaker.Architecture.GameStates.Gameplay;
using BlockBreaker.Data.Dynamic.Obstacle;
using BlockBreaker.Data.Static.Configuration.Obstacle;
using BlockBreaker.Features.Obstacle;
using BlockBreaker.Features.Player;
using BlockBreaker.Features.Player.Bullet;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class ObstacleBindingInstaller: MonoInstaller
    {
        [SerializeField] private ObstacleDataProvider[] obstacles;
        [SerializeField] private ObstacleConfig obstacleConfig;

        public override void InstallBindings()
        {
            BindConfig();
            BindConfigurator();
            BindObstaclesProvider();
            BindData();
            BindObstacleDestroyer();
        }

        private void BindConfig()
        {
            Container
                .BindInterfacesAndSelfTo<ObstacleConfig>()
                .FromScriptableObject(obstacleConfig)
                .AsCached()
                .WhenInjectedInto<ObstacleConfigurator>();
        }

        private void BindConfigurator()
        {
            Container
                .BindInterfacesTo<ObstacleConfigurator>()
                .AsSingle()
                .WhenInjectedInto<SetupGameplayState>();
        }

        private void BindObstaclesProvider()
        {
            Container
                .BindInterfacesAndSelfTo<ObstaclesProvider>()
                .AsSingle()
                .WithArguments(obstacles)
                .WhenInjectedInto(typeof(SetupGameplayState), typeof(ProcessGameplayState),
                    typeof(PlayerBulletExploder), typeof(ObstacleDestroyer),
                    typeof(PlayerVictoryChecker), typeof(PlayerDefeatChecker));
        }

        private void BindData()
        {
            Container
                .BindInterfacesAndSelfTo<ObstacleData>()
                .AsTransient()
                .WhenInjectedInto<ObstacleDataProvider>();
        }

        private void BindObstacleDestroyer()
        {
            Container
                .BindInterfacesAndSelfTo<ObstacleDestroyer>()
                .AsSingle()
                .WhenInjectedInto<ObstacleConfigurator>();
        }
    }
}