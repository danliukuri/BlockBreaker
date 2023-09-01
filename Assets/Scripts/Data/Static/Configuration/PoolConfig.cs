using UnityEngine;

namespace BlockBreaker.Data.Static.Configuration
{
    [CreateAssetMenu(fileName = nameof(PoolConfig), menuName = "Configuration/Object Pool")]
    public class PoolConfig : ScriptableObject, IPoolConfig
    {
        [field: SerializeField, Min(default)] public int StartCount { get; private set; }
        [field: SerializeField, Min(default)] public int StartCapacity { get; private set; }
        [field: SerializeField, Min(default)] public int MaxSize { get; private set; }
        [field: SerializeField] public bool ThrowErrorIfItemAlreadyInPoolWhenRelease { get; private set; } = true;
    }
}