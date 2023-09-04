using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Data.Static.Configuration.Player.Carpet;
using BlockBreaker.Infrastructure.Services;
using UnityEngine;

namespace BlockBreaker.Features.Player.Carpet
{
    public class PlayerCarpetConfigurator : IComponentConfigurator<PlayerCarpetDataProvider>
    {
        private readonly PlayerCarpetConfig _config;
        private readonly Transform _spawnPoint;

        public PlayerCarpetConfigurator(PlayerCarpetConfig config, Transform spawnPoint)
        {
            _config = config;
            _spawnPoint = spawnPoint;
        }

        public void Configure(PlayerCarpetDataProvider component)
        {
            PlayerCarpetData data = component.Data;
            data.Config = _config;
            data.Transform = component.transform;
            data.Transform.position = _spawnPoint.position;
        }
    }
}