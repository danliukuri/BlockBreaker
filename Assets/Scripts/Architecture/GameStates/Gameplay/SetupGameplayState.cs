using BlockBreaker.Features.Obstacle;
using BlockBreaker.Features.Player;
using BlockBreaker.Features.Player.Carpet;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Utilities.Patterns.State;
using UnityEngine;
using UnityEngine.Pool;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class SetupGameplayState : IEnterableState
    {
        private readonly ObstacleDataProvider[] _blockObstacles;
        private readonly IObjectPool<PlayerCarpetDataProvider> _playerCarpetPool;
        private readonly IObjectPool<PlayerDataProvider> _playerPool;
        private readonly IActiveService[] _services;

        public SetupGameplayState(IObjectPool<PlayerCarpetDataProvider> playerCarpetPool,
            IObjectPool<PlayerDataProvider> playerPool, ObstacleDataProvider[] blockObstacles,
            IActiveService[] services)
        {
            _playerCarpetPool = playerCarpetPool;
            _playerPool = playerPool;
            _blockObstacles = blockObstacles;
            _services = services;
        }

        public void Enter()
        {
            PlayerDataProvider player = _playerPool.Get();
            PlayerCarpetDataProvider carpet = _playerCarpetPool.Get();
            SetUpPlayer(player, carpet);

            foreach (IActiveService service in _services)
                service.Enable();
        }

        private void SetUpPlayer(PlayerDataProvider player, PlayerCarpetDataProvider carpet)
        {
            Transform playerTransform = player.transform;

            var playerSizeCalculator = new PLayerSizeCalculator(player.Config, carpet);
            var playerSizeSetter = new PlayerSizeSetter(playerTransform);
            var carpetSizeSetter = new PlayerCarpetSizeSetter(carpet.transform);

            float newPlayerSize = playerSizeCalculator.CalculateSize(_blockObstacles);
            playerSizeSetter.Set(newPlayerSize);
            carpetSizeSetter.Set(newPlayerSize);
        }
    }
}