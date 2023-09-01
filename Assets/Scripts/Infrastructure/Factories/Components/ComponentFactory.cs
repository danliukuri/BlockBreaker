using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Utilities.Extensions.Unity;
using UnityEngine;

namespace BlockBreaker.Infrastructure.Factories.Components
{
    public class ComponentFactory<TComponent> : IComponentFactory<TComponent> where TComponent : Component
    {
        protected readonly IFactoryConfig _config;
        private readonly IComponentConfigurator<TComponent> _configurator;
        protected readonly Transform _objectParent;

        public ComponentFactory(IFactoryConfig config, IComponentConfigurator<TComponent> configurator,
            Transform objectParent = default)
        {
            _config = config;
            _configurator = configurator;
            _objectParent = objectParent;
        }

        public virtual TComponent Create() =>
            _config.Prefab.AsInactive(Object.Instantiate, _objectParent).GetComponent<TComponent>();

        public void ConfigureGameObject(TComponent component)
        {
            _configurator.Configure(component);
            component.gameObject.SetActive(true);
        }

        public void DeactivateGameObject(TComponent component) => component.gameObject.SetActive(false);

        public void DestroyGameObject(TComponent component) => Object.Destroy(component.gameObject);
    }
}