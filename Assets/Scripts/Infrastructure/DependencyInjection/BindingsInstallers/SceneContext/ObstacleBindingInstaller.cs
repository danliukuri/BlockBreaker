using BlockBreaker.Architecture.GameStates.Gameplay;
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
            BindObstacles();
        }

        private void BindConfig()
        {
            Container
                .BindInterfacesAndSelfTo<ObstacleConfig>()
                .FromScriptableObject(obstacleConfig)
                .AsCached()
                .WhenInjectedInto<ObstacleDataProvider>();
        }

        private void BindObstacles()
        {
            Container
                .BindInterfacesAndSelfTo<ObstacleDataProvider[]>()
                .FromInstance(obstacles)
                .AsSingle()
                .WhenInjectedInto<SetupGameplayState>();
        }
    }
}