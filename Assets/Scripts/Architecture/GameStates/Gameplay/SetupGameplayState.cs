using BlockBreaker.Features.Player;
using BlockBreaker.Features.Player.Carpet;
using BlockBreaker.Utilities.Patterns.State;
using UnityEngine.Pool;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class SetupGameplayState : IEnterableState
    {
        private readonly IObjectPool<PlayerMarker> _playerPool;
        private readonly IObjectPool<PlayerCarpetMarker> _playerCarpetPool;

        public SetupGameplayState(IObjectPool<PlayerMarker> playerPool,
            IObjectPool<PlayerCarpetMarker> playerCarpetPool)
        {
            _playerCarpetPool = playerCarpetPool;
            _playerPool =
                playerPool;
        }

        public void Enter()
        {
            _playerPool.Get();
            _playerCarpetPool.Get();
        }
    }
}