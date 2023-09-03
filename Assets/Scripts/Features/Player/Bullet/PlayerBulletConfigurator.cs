using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Data.Static.Configuration.Player.Bullet;
using BlockBreaker.Infrastructure.Services;
using UnityEngine;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletConfigurator : IComponentConfigurator<PlayerBulletDataProvider>
    {
        private readonly PlayerBulletData _bullet;
        private readonly PlayerBulletConfig _config;
        private readonly PlayerData _player;

        public PlayerBulletConfigurator(PlayerBulletData bullet, PlayerBulletConfig config, PlayerData player)
        {
            _bullet = bullet;
            _config = config;
            _player = player;
        }

        public void Configure(PlayerBulletDataProvider component)
        {
            Transform transform = _bullet.Transform = component.transform;
            _bullet.Config = _config;
            _bullet.Size = _config.Size;
            _bullet.Radius = _config.Radius;

            transform.localScale = Vector3.one * _config.Size;

            Vector3 initialPosition = _bullet.InitialPosition =
                _config.SpawnDirection * (_player.Radius + _config.Radius) + _player.InitialPosition;
            transform.position = new Vector3(initialPosition.x, initialPosition.y + _bullet.Radius, initialPosition.z);
        }
    }
}