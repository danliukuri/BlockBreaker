using BlockBreaker.Infrastructure.Services;
using UnityEngine;

namespace BlockBreaker.Features.Player.Configurators
{
    public class PlayerConfigurator : IComponentConfigurator<PlayerMarker>
    {
        private readonly Transform _spawnPoint;

        public PlayerConfigurator(Transform spawnPoint) => _spawnPoint = spawnPoint;

        public void Configure(PlayerMarker component) => component.transform.position = _spawnPoint.position;
    }
}