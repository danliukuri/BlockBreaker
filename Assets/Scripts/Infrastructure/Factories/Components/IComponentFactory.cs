using UnityEngine;
using Zenject;

namespace BlockBreaker.Infrastructure.Factories.Components
{
    public interface IComponentFactory<TComponent> : IFactory<TComponent> where TComponent : Component
    {
        void ConfigureGameObject(TComponent component);
        void DeactivateGameObject(TComponent component);
        void DestroyGameObject(TComponent component);
    }
}