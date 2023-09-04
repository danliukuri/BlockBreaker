using BlockBreaker.Architecture.GameStates.Gameplay;
using BlockBreaker.Data.Dynamic.Obstacle;
using BlockBreaker.Data.Static.Configuration.Obstacle;
using BlockBreaker.Features.Obstacle;
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
                .WhenInjectedInto<SetupGameplayState>();
        }

        private void BindData()
        {
            Container
                .BindInterfacesAndSelfTo<ObstacleData>()
                .AsTransient()
                .WhenInjectedInto<ObstacleDataProvider>();
        }
    }
}