using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Data.Static.Configuration.Player.Bullet;
using BlockBreaker.Features.Player.Bullet;
using BlockBreaker.Infrastructure.Factories.Components;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext.Player
{
    public class PlayerBulletBindingInstaller : MonoInstaller
    {
        [SerializeField] private PlayerBulletConfig playerBulletConfig;
        [SerializeField] private FactoryConfig factoryConfig;
        [SerializeField] private PoolConfig poolConfig;

        public override void InstallBindings()
        {
            BindConfigurator();
            BindResetter();
            BindFactory();
            BindObjectPool();
            BindConfig();
            BindData();
            BindDestroyer();
            BindExploder();
        }

        private void BindConfigurator()
        {
            Container
                .BindInterfacesTo<PlayerBulletConfigurator>()
                .AsSingle()
                .WhenInjectedInto<IComponentFactory<PlayerBulletDataProvider>>();
        }

        private void BindResetter()
        {
            Container
                .BindInterfacesTo<PlayerBulletResetter>()
                .AsSingle()
                .WhenInjectedInto<IComponentFactory<PlayerBulletDataProvider>>();
        }

        private void BindFactory()
        {
            Container
                .BindInterfacesTo<FactoryConfig>()
                .FromScriptableObject(factoryConfig)
                .AsCached()
                .WhenInjectedInto<IComponentFactory<PlayerBulletDataProvider>>();
            
            Container.BindInterfacesTo<DependentComponentFactory<PlayerBulletDataProvider>>().AsSingle();
        }

        private void BindObjectPool()
        {
            Container
                .BindInterfacesTo<PoolConfig>()
                .FromScriptableObject(poolConfig)
                .AsCached()
                .WhenInjectedInto<ComponentPoolFactory<PlayerBulletDataProvider>>();

            Container
                .Bind<IObjectPool<PlayerBulletDataProvider>>()
                .To<ObjectPool<PlayerBulletDataProvider>>()
                .FromFactory<ComponentPoolFactory<PlayerBulletDataProvider>>()
                .AsSingle();
        }

        private void BindConfig()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerBulletConfig>()
                .FromScriptableObject(playerBulletConfig)
                .AsCached()
                .WhenInjectedInto<PlayerBulletConfigurator>();
        }

        private void BindData()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerBulletData>()
                .AsTransient()
                .WhenInjectedInto<PlayerBulletDataProvider>();
        }

        private void BindDestroyer()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerBulletDestroyer>()
                .AsSingle()
                .WhenInjectedInto<PlayerBulletConfigurator>();
        }

        private void BindExploder()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerBulletExploder>()
                .AsSingle()
                .WhenInjectedInto<PlayerBulletConfigurator>();
        }
    }
}