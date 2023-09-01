using BlockBreaker.Infrastructure.Services;
using UnityEngine;

namespace BlockBreaker.Features.Player.Carpet
{
    public class PlayerCarpetConfigurator : IComponentConfigurator<PlayerCarpetMarker>
    {
        private readonly Transform _spawnPoint;

        public PlayerCarpetConfigurator(Transform spawnPoint) => _spawnPoint = spawnPoint;

        public void Configure(PlayerCarpetMarker component) => component.transform.position = _spawnPoint.position;
    }
}