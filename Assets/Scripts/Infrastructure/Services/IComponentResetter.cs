using UnityEngine;

namespace BlockBreaker.Infrastructure.Services
{
    public interface IComponentResetter<in TComponent> where TComponent : Component
    {
        void Reset(TComponent component);
    }
}