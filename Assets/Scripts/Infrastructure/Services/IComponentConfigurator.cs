using UnityEngine;

namespace BlockBreaker.Infrastructure.Services
{
    public interface IComponentConfigurator<in TComponent> where TComponent : Component
    {
        public void Configure(TComponent component);
    }
}