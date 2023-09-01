using BlockBreaker.Features.Player;
using BlockBreaker.Utilities.Patterns.State;
using UnityEngine.Pool;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class SetupGameplayState : IEnterableState
    {
        private readonly IObjectPool<PlayerMarker> _playerPool;

        public SetupGameplayState(IObjectPool<PlayerMarker> playerPool) => _playerPool = playerPool;

        public void Enter() => _playerPool.Get();
    }
}