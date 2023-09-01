using BlockBreaker.Data.Static.Configuration;
using BlockBreaker.Utilities.Extensions.Unity;
using UnityEngine;

namespace BlockBreaker.Infrastructure.Factories.Components
{
    public class ComponentFactory<TComponent> : IComponentFactory<TComponent> where TComponent : Component
    {
        protected readonly IFactoryConfig _config;
        protected readonly Transform _objectParent;

        public ComponentFactory(IFactoryConfig config, Transform objectParent = default)
        {
            _config = config;
            _objectParent = objectParent;
        }

        public virtual TComponent Create() =>
            _config.Prefab.AsInactive(Object.Instantiate, _objectParent).GetComponent<TComponent>();

        public void ActivateGameObject(TComponent component) => component.gameObject.SetActive(true);

        public void DeactivateGameObject(TComponent component) => component.gameObject.SetActive(false);

        public void DestroyGameObject(TComponent component) => Object.Destroy(component.gameObject);
    }
}