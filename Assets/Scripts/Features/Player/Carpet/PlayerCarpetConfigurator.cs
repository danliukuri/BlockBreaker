using BlockBreaker.Infrastructure.Services;
using UnityEngine;

namespace BlockBreaker.Features.Player.Carpet
{
    public class PlayerCarpetConfigurator : IComponentConfigurator<PlayerCarpetDataProvider>
    {
        private readonly Transform _spawnPoint;

        public PlayerCarpetConfigurator(Transform spawnPoint) => _spawnPoint = spawnPoint;

        public void Configure(PlayerCarpetDataProvider component) => component.transform.position = _spawnPoint.position;
    }
}