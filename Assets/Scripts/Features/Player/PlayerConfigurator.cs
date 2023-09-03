using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Data.Static.Configuration.Player;
using BlockBreaker.Infrastructure.Services;
using UnityEngine;

namespace BlockBreaker.Features.Player
{
    public class PlayerConfigurator : IComponentConfigurator<PlayerDataProvider>
    {
        private readonly PlayerConfig _config;
        private readonly PlayerData _playerData;
        private readonly Transform _spawnPoint;

        public PlayerConfigurator(PlayerConfig config, PlayerData playerData, Transform spawnPoint)
        {
            _config = config;
            _playerData = playerData;
            _spawnPoint = spawnPoint;
        }

        public void Configure(PlayerDataProvider component)
        {
            _playerData.Transform = component.transform;
            _playerData.Config = _config;
            _playerData.Size = _config.Size;
            _playerData.Radius = _config.Radius;
            _playerData.InitialPosition = _playerData.Transform.position = _spawnPoint.position;
        }
    }
}