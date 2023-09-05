using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Features.UI;
using BlockBreaker.Infrastructure.Factories.Components;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class UIBindingsInstaller : MonoInstaller
    {
        [SerializeField] private Transform uiRoot;
        [SerializeField] private GameObject canvas;

        [SerializeField] private FactoryConfig defeatTextFactoryConfig;
        [SerializeField] private PoolConfig defeatTextPoolConfig;

        public override void InstallBindings()
        {
            BindConfigurator();

            BindDefeatTextFactory();
            BindDefeatTextObjectPool();
        }

        private void BindConfigurator()
        {
            Container
                .BindInterfacesTo<UIConfigurator>()
                .AsSingle()
                .WithArguments(canvas, uiRoot)
                .WhenInjectedInto(typeof(IComponentFactory<DefeatTextMarker>),
                    typeof(IComponentFactory<VictoryTextMarker>));
        }

        private void BindDefeatTextFactory()
        {
            Container
                .BindInterfacesTo<FactoryConfig>()
                .FromScriptableObject(defeatTextFactoryConfig)
                .AsCached()
                .WhenInjectedInto<ComponentFactory<DefeatTextMarker>>();

            Container.BindInterfacesTo<ComponentFactory<DefeatTextMarker>>().AsCached();
        }

        private void BindDefeatTextObjectPool()
        {
            Container
                .BindInterfacesTo<PoolConfig>()
                .FromScriptableObject(defeatTextPoolConfig)
                .AsCached()
                .WhenInjectedInto<ComponentPoolFactory<DefeatTextMarker>>();

            Container
                .Bind<IObjectPool<DefeatTextMarker>>()
                .To<ObjectPool<DefeatTextMarker>>()
                .FromFactory<ComponentPoolFactory<DefeatTextMarker>>()
                .AsCached();
        }
    }
}