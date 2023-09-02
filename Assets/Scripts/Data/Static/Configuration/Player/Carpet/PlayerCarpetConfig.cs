using UnityEngine;

namespace BlockBreaker.Data.Static.Configuration.Player.Carpet
{
    [CreateAssetMenu(fileName = nameof(PlayerCarpetConfig), menuName = "Configuration/Player/Carpet")]
    public class PlayerCarpetConfig : ScriptableObject
    {
        [field: SerializeField, Min(default)] public Vector3 Radius { get; private set; }
    }
}