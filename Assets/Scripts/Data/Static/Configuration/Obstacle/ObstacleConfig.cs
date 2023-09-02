using UnityEngine;

namespace BlockBreaker.Data.Static.Configuration.Obstacle
{
    [CreateAssetMenu(fileName = nameof(ObstacleConfig), menuName = "Configuration/Obstacle/BlockObstacle")]
    public class ObstacleConfig : ScriptableObject
    {
        [field: SerializeField, Min(default)] public int HealthPoints { get; private set; }
        [field: SerializeField, Min(default)] public Vector3 Radius { get; private set; }
    }
}