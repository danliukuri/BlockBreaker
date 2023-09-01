using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Features.Player.Carpet;
using BlockBreaker.Infrastructure.Factories.Components;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class PlayerCarpetBindingsInstaller : MonoInstaller
    {
        [SerializeField] private Transform spawnPoint;

        [SerializeField] private FactoryConfig factoryConfig;
        [SerializeField] private PoolConfig poolConfig;

        public override void InstallBindings()
        {
            BindConfigurator();
            BindFactory();
            BindObjectPool();
        }

        private void BindConfigurator()
        {
            Container
                .BindInterfacesTo<PlayerCarpetConfigurator>()
                .AsSingle()
                .WithArguments(spawnPoint)
                .WhenInjectedInto<ComponentFactory<PlayerCarpetMarker>>();
        }

        private void BindFactory()
        {
            Container
                .BindInterfacesTo<FactoryConfig>()
                .FromScriptableObject(factoryConfig)
                .AsCached()
                .WhenInjectedInto<ComponentFactory<PlayerCarpetMarker>>();

            Container.BindInterfacesTo<ComponentFactory<PlayerCarpetMarker>>().AsSingle();
        }

        private void BindObjectPool()
        {
            Container
                .BindInterfacesTo<PoolConfig>()
                .FromScriptableObject(poolConfig)
                .AsCached()
                .WhenInjectedInto<ComponentPoolFactory<PlayerCarpetMarker>>();

            Container
                .Bind<IObjectPool<PlayerCarpetMarker>>()
                .To<ObjectPool<PlayerCarpetMarker>>()
                .FromFactory<ComponentPoolFactory<PlayerCarpetMarker>>()
                .AsSingle();
        }
    }
}