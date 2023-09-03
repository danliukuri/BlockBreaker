using UnityEngine;

namespace BlockBreaker.Data.Static.Configuration.Player.Bullet
{
    [CreateAssetMenu(fileName = nameof(PlayerBulletConfig), menuName = "Configuration/Player/Bullet")]
    public class PlayerBulletConfig : ScriptableObject
    {
        [field: SerializeField, Min(default)] public float CreationSpeed { get; private set; }
        [field: SerializeField, Min(default)] public Vector3 SpawnDirection { get; private set; }
        [field: SerializeField, Min(default)] public float Size { get; private set; }
        public float Radius => Size / 2f;
    }
}