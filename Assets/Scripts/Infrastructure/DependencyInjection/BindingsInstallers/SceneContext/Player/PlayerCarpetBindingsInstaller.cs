using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Data.Static.Configuration.Player.Carpet;
using BlockBreaker.Features.Player.Carpet;
using BlockBreaker.Infrastructure.Factories.Components;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext.Player
{
    public class PlayerCarpetBindingsInstaller : MonoInstaller
    {
        [SerializeField] private Transform spawnPoint;

        [SerializeField] private PlayerCarpetConfig playerCarpetConfig;
        [SerializeField] private FactoryConfig factoryConfig;
        [SerializeField] private PoolConfig poolConfig;

        public override void InstallBindings()
        {
            BindConfigurator();
            BindFactory();
            BindObjectPool();
            BindConfig();
        }

        private void BindConfigurator()
        {
            Container
                .BindInterfacesTo<PlayerCarpetConfigurator>()
                .AsSingle()
                .WithArguments(spawnPoint)
                .WhenInjectedInto<DependentComponentFactory<PlayerCarpetDataProvider>>();
        }

        private void BindFactory()
        {
            Container
                .BindInterfacesTo<FactoryConfig>()
                .FromScriptableObject(factoryConfig)
                .AsCached()
                .WhenInjectedInto<DependentComponentFactory<PlayerCarpetDataProvider>>();

            Container.BindInterfacesTo<DependentComponentFactory<PlayerCarpetDataProvider>>().AsSingle();
        }

        private void BindObjectPool()
        {
            Container
                .BindInterfacesTo<PoolConfig>()
                .FromScriptableObject(poolConfig)
                .AsCached()
                .WhenInjectedInto<ComponentPoolFactory<PlayerCarpetDataProvider>>();

            Container
                .Bind<IObjectPool<PlayerCarpetDataProvider>>()
                .To<ObjectPool<PlayerCarpetDataProvider>>()
                .FromFactory<ComponentPoolFactory<PlayerCarpetDataProvider>>()
                .AsSingle();
        }

        private void BindConfig()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerCarpetConfig>()
                .FromScriptableObject(playerCarpetConfig)
                .AsCached()
                .WhenInjectedInto<PlayerCarpetDataProvider>();
        }
    }
}