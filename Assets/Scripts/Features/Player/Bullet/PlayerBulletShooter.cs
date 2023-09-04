using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;
using UnityEngine.Pool;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletShooter
    {
        private readonly IObjectPool<PlayerBulletDataProvider> _bulletsPool;
        private readonly PlayerData _player;

        private PlayerBulletData _currentBullet;

        public PlayerBulletShooter(IObjectPool<PlayerBulletDataProvider> bulletsPool, PlayerData player)
        {
            _player = player;
            _bulletsPool = bulletsPool;
        }

        public void InstantiateBullet()
        {
            _currentBullet = _bulletsPool.Get().Data;
            _currentBullet.Destroyer.BulletsPool = _bulletsPool;
        }

        public void ShootBullet() => Shoot(_currentBullet);

        private void Shoot(PlayerBulletData bullet)
        {
            float shootingForce = _player.Config.ShootingForce * bullet.Size;
            bullet.Rigidbody.AddForce(bullet.Config.SpawnDirection * shootingForce, ForceMode.Impulse);
        }

        public void ChargeBullet() =>
            _player.SizeConverter.Convert(_currentBullet, _currentBullet.Config.CreationSpeed * Time.deltaTime);
    }
}