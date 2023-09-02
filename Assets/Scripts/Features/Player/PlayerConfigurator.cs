using BlockBreaker.Infrastructure.Services;
using UnityEngine;

namespace BlockBreaker.Features.Player
{
    public class PlayerConfigurator : IComponentConfigurator<PlayerDataProvider>
    {
        private readonly Transform _spawnPoint;

        public PlayerConfigurator(Transform spawnPoint) => _spawnPoint = spawnPoint;

        public void Configure(PlayerDataProvider component) => component.transform.position = _spawnPoint.position;
    }
}