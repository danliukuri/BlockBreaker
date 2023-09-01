using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Utilities.Extensions.Unity;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Infrastructure.Factories.Components
{
    public class DependentComponentFactory<TComponent> : ComponentFactory<TComponent> where TComponent : Component
    {
        private readonly IInstantiator _instantiator;

        public DependentComponentFactory(IFactoryConfig config, Transform objectParent, IInstantiator instantiator) :
            base(config, objectParent) => _instantiator = instantiator;

        public override TComponent Create() =>
            _config.Prefab.AsInactive(_instantiator.InstantiatePrefabForComponent<TComponent>, _objectParent);
    }
}