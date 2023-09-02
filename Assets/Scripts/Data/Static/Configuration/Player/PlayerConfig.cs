using UnityEngine;

namespace BlockBreaker.Data.Static.Configuration.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configuration/Player/Data")]
    public class PlayerConfig : ScriptableObject
    {
        private const float MinPercentage = 0f, MaxPercentage = 1f; 
        [field: SerializeField, Min(default)] public float HealthPointsToScaleRatio { get; private set; }
        [field: SerializeField, Min(default)] public float MinSize { get; private set; }
        [field: SerializeField, Range(MinPercentage, MaxPercentage)]
        public float SizeReserveProportion { get; private set; }
    }
}