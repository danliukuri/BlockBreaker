using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Data.Static.Configuration.Player.Bullet;
using BlockBreaker.Infrastructure.Services;
using UnityEngine;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletConfigurator : IComponentConfigurator<PlayerBulletDataProvider>
    {
        private readonly PlayerBulletDestroyer _bulletDestroyer;
        private readonly PlayerBulletExploder _bulletExploder;
        private readonly PlayerBulletConfig _config;
        private readonly PlayerData _player;

        public PlayerBulletConfigurator(PlayerBulletDestroyer bulletDestroyer, PlayerBulletExploder bulletExploder,
            PlayerBulletConfig config, PlayerData player)
        {
            _bulletDestroyer = bulletDestroyer;
            _bulletExploder = bulletExploder;
            _config = config;
            _player = player;
        }

        public void Configure(PlayerBulletDataProvider component)
        {
            PlayerBulletData bullet = component.Data;
            bullet.InitialPosition = ConfigureInitialPosition();
            bullet.Transform = ConfigureTransform(component.transform, bullet);
            bullet.Rigidbody = component.GetComponent<Rigidbody>();
            bullet.Config = _config;
            bullet.Size = _config.Size;
            bullet.Radius = _config.Radius;
            bullet.Destroyer = _bulletDestroyer;
            bullet.Exploder = _bulletExploder;
            bullet.IsDestroyed = false;
        }

        private Vector3 ConfigureInitialPosition() =>
            _config.SpawnDirection * (_player.Radius + _config.Radius) + _player.InitialPosition;

        private Transform ConfigureTransform(Transform transform, PlayerBulletData bullet)
        {
            transform.localScale = Vector3.one * _config.Size;
            Vector3 initialPosition = bullet.InitialPosition;
            transform.position = new Vector3(initialPosition.x, initialPosition.y + bullet.Radius, initialPosition.z);
            return transform;
        }
    }
}