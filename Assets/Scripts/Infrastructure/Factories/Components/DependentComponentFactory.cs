using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Utilities.Extensions.Unity;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Infrastructure.Factories.Components
{
    public class DependentComponentFactory<TComponent> : ComponentFactory<TComponent> where TComponent : Component
    {
        private readonly IInstantiator _instantiator;

        public DependentComponentFactory(IFactoryConfig config, IComponentConfigurator<TComponent> configurator, 
            IInstantiator instantiator, Transform objectParent = default) :
            base(config, configurator, objectParent) => _instantiator = instantiator;

        public override TComponent Create() =>
            _config.Prefab.AsInactive(_instantiator.InstantiatePrefabForComponent<TComponent>, _objectParent);
    }
}