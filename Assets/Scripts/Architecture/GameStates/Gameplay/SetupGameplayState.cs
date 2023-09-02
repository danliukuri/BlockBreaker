using BlockBreaker.Features.Obstacle;
using BlockBreaker.Features.Player;
using BlockBreaker.Features.Player.Carpet;
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

        public SetupGameplayState(IObjectPool<PlayerCarpetDataProvider> playerCarpetPool,
            IObjectPool<PlayerDataProvider> playerPool, ObstacleDataProvider[] blockObstacles)
        {
            _playerCarpetPool = playerCarpetPool;
            _playerPool = playerPool;
            _blockObstacles = blockObstacles;
        }

        public void Enter()
        {
            PlayerDataProvider player = _playerPool.Get();
            PlayerCarpetDataProvider carpet = _playerCarpetPool.Get();
            Transform playerTransform = player.transform;

            var playerSizeSetter = new PlayerSizeSetter(playerTransform);
            var carpetSizeSetter = new PlayerCarpetSizeSetter(carpet.transform);
        }
    }
}