using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Features.Player;
using BlockBreaker.Infrastructure.Factories.Components;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class PlayerBindingsInstaller : MonoInstaller
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
                .BindInterfacesTo<PlayerConfigurator>()
                .AsSingle()
                .WithArguments(spawnPoint)
                .WhenInjectedInto<ComponentFactory<PlayerMarker>>();
        }

        private void BindFactory()
        {
            Container
                .BindInterfacesTo<FactoryConfig>()
                .FromScriptableObject(factoryConfig)
                .AsCached()
                .WhenInjectedInto<ComponentFactory<PlayerMarker>>();

            Container.BindInterfacesTo<ComponentFactory<PlayerMarker>>().AsSingle();
        }

        private void BindObjectPool()
        {
            Container
                .BindInterfacesTo<PoolConfig>()
                .FromScriptableObject(poolConfig)
                .AsCached()
                .WhenInjectedInto<ComponentPoolFactory<PlayerMarker>>();

            Container
                .Bind<IObjectPool<PlayerMarker>>()
                .To<ObjectPool<PlayerMarker>>()
                .FromFactory<ComponentPoolFactory<PlayerMarker>>()
                .AsSingle();
        }
    }
}