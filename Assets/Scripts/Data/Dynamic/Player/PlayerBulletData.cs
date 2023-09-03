using BlockBreaker.Data.Static.Configuration.Player.Bullet;
using UnityEngine;

namespace BlockBreaker.Data.Dynamic.Player
{
    public class PlayerBulletData
    {
        public PlayerBulletConfig Config { get; set; }
        public Transform Transform { get; set; }
        public Rigidbody Rigidbody { get; set; }
        public Vector3 InitialPosition { get; set; }
        public float Size { get; set; }
        public float Radius { get; set; }
    }
}