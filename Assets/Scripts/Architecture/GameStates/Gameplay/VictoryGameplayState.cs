using BlockBreaker.Features.Player;
using BlockBreaker.Features.UI;
using BlockBreaker.Utilities.Patterns.State;
using UnityEngine.Pool;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class VictoryGameplayState : IEnterableState
    {
        private readonly PlayerMover _playerMover;
        private readonly IObjectPool<VictoryTextMarker> _victoryTexts;

        public VictoryGameplayState(PlayerMover playerMover, IObjectPool<VictoryTextMarker> victoryTexts)
        {
            _playerMover = playerMover;
            _victoryTexts = victoryTexts;
        }

        public void Enter()
        {
            _playerMover.Move();
            _victoryTexts.Get();
        }
    }
}