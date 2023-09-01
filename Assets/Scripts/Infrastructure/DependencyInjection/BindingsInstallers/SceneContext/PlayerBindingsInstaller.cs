using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Features.Player;
using BlockBreaker.Features.Player.Configurators;
using BlockBreaker.Infrastructure.Factories.Components;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class PlayerBindingsInstaller : MonoInstaller
    {
        [SerializeField] private Transform playerObjectsParent;
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
                .AsSingle()
                .WhenInjectedInto<ComponentFactory<PlayerMarker>>();

            Container
                .BindInterfacesTo<ComponentFactory<PlayerMarker>>()
                .AsSingle()
                .WithArguments(playerObjectsParent);
        }

        private void BindObjectPool()
        {
            Container
                .BindInterfacesTo<PoolConfig>()
                .FromScriptableObject(poolConfig)
                .AsSingle()
                .WhenInjectedInto<ComponentPoolFactory<PlayerMarker>>();

            Container
                .Bind<IObjectPool<PlayerMarker>>()
                .To<ObjectPool<PlayerMarker>>()
                .FromFactory<ComponentPoolFactory<PlayerMarker>>()
                .AsSingle();
        }
    }
}