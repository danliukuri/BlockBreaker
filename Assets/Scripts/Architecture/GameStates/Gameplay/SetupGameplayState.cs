using BlockBreaker.Features.Obstacle;
using BlockBreaker.Features.Player;
using BlockBreaker.Features.Player.Carpet;
using BlockBreaker.Utilities.Patterns.State;
using UnityEngine.Pool;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class SetupGameplayState : IEnterableState
    {
        private readonly ObstacleDataProvider[] _blockObstacles;
        private readonly IObjectPool<PlayerCarpetMarker> _playerCarpetPool;
        private readonly IObjectPool<PlayerMarker> _playerPool;

        public SetupGameplayState(IObjectPool<PlayerCarpetMarker> playerCarpetPool,
            IObjectPool<PlayerMarker> playerPool, ObstacleDataProvider[] blockObstacles)
        {
            _playerCarpetPool = playerCarpetPool;
            _playerPool = playerPool;
            _blockObstacles = blockObstacles;
        }

        public void Enter()
        {
            _playerPool.Get();
            _playerCarpetPool.Get();
        }
    }
}