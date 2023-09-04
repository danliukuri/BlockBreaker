using BlockBreaker.Features.Player;
using BlockBreaker.Utilities.Patterns.State;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class VictoryGameplayState : IEnterableState
    {
        private readonly PlayerMover _playerMover;

        public VictoryGameplayState(PlayerMover playerMover) => _playerMover = playerMover;
        
        public void Enter() => _playerMover.Move();
    }
}