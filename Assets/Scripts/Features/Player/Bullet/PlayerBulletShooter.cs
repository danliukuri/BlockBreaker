using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;
using UnityEngine.Pool;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletShooter
    {
        private readonly IObjectPool<PlayerBulletDataProvider> _bulletsPool;
        private readonly PlayerData _player;

        public PlayerBulletShooter(IObjectPool<PlayerBulletDataProvider> bulletsPool, PlayerData player)
        {
            _player = player;
            _bulletsPool = bulletsPool;
        }

        public void Shoot(PlayerBulletData bullet)
        {
            float shootingForce = _player.Config.ShootingForce * bullet.Size;
            bullet.Rigidbody.AddForce(bullet.Config.SpawnDirection * shootingForce, ForceMode.Impulse);
            bullet.Destroyer.BulletsPool = _bulletsPool;
        }
    }
}