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
        private readonly IObjectPool<PlayerDataProvider> _playerPool;

        public SetupGameplayState(IObjectPool<PlayerCarpetMarker> playerCarpetPool,
            IObjectPool<PlayerDataProvider> playerPool, ObstacleDataProvider[] blockObstacles)
        {
            _playerCarpetPool = playerCarpetPool;
            _playerPool = playerPool;
            _blockObstacles = blockObstacles;
        }

        public void Enter()
        {
            PlayerDataProvider player = _playerPool.Get();
            PlayerCarpetMarker playerCarpet = _playerCarpetPool.Get();

            var playerSizeChanger = new PlayerSizeChanger(player.transform, player.PlayerConfig);
            playerSizeChanger.IncreaseSize(_blockObstacles);
        }
    }
}