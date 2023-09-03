using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletShooter
    {
        private readonly PlayerData _player;

        public PlayerBulletShooter(PlayerData player) => _player = player;

        public void Shoot(PlayerBulletData bullet)
        {
            float shootingForce = _player.Config.ShootingForce * bullet.Size;
            bullet.Rigidbody.AddForce(bullet.Config.SpawnDirection * shootingForce, ForceMode.Impulse);
        }
    }
}