using BlockBreaker.Architecture.GameStates.Gameplay;
using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Data.Static.Configuration.Player;
using BlockBreaker.Features.Player;
using BlockBreaker.Features.Player.Bullet;
using BlockBreaker.Infrastructure.Factories.Components;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext.Player
{
    public class PlayerBindingsInstaller : MonoInstaller
    {
        [SerializeField] private Transform spawnPoint;

        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private FactoryConfig factoryConfig;
        [SerializeField] private PoolConfig poolConfig;

        public override void InstallBindings()
        {
            BindConfigurator();
            BindFactory();
            BindObjectPool();
            BindConfig();
            BindInputHandler();
            BindData();
            BindVictoryChecker();
            BindDefeatChecker();
            BindMover();
        }

        private void BindConfigurator()
        {
            Container
                .BindInterfacesTo<PlayerConfigurator>()
                .AsSingle()
                .WithArguments(spawnPoint)
                .WhenInjectedInto<DependentComponentFactory<PlayerDataProvider>>();
        }

        private void BindFactory()
        {
            Container
                .BindInterfacesTo<FactoryConfig>()
                .FromScriptableObject(factoryConfig)
                .AsCached()
                .WhenInjectedInto<DependentComponentFactory<PlayerDataProvider>>();

            Container.BindInterfacesTo<DependentComponentFactory<PlayerDataProvider>>().AsSingle();
        }

        private void BindObjectPool()
        {
            Container
                .BindInterfacesTo<PoolConfig>()
                .FromScriptableObject(poolConfig)
                .AsCached()
                .WhenInjectedInto<ComponentPoolFactory<PlayerDataProvider>>();

            Container
                .Bind<IObjectPool<PlayerDataProvider>>()
                .To<ObjectPool<PlayerDataProvider>>()
                .FromFactory<ComponentPoolFactory<PlayerDataProvider>>()
                .AsSingle();
        }

        private void BindConfig()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerConfig>()
                .FromScriptableObject(playerConfig)
                .AsCached()
                .WhenInjectedInto<PlayerConfigurator>();
        }

        private void BindInputHandler()
        {
            Container
                .BindInterfacesTo<PlayerInputHandler>()
                .AsSingle()
                .WhenInjectedInto<ProcessGameplayState>();
        }

        private void BindData()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerData>()
                .AsSingle()
                .WhenInjectedInto(typeof(PlayerDataProvider), typeof(PlayerConfigurator), typeof(PlayerMover),
                    typeof(PlayerBulletConfigurator), typeof(PlayerInputHandler), typeof(PlayerDefeatChecker));
        }

        private void BindVictoryChecker()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerVictoryChecker>()
                .AsSingle()
                .WhenInjectedInto(typeof(ProcessGameplayState), typeof(PlayerInputHandler));
        }

        private void BindDefeatChecker()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerDefeatChecker>()
                .AsSingle()
                .WhenInjectedInto<PlayerInputHandler>();
        }

        private void BindMover()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerMover>()
                .AsSingle()
                .WhenInjectedInto<VictoryGameplayState>();
        }
    }
}