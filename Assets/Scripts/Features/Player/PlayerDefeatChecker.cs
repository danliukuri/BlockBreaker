using BlockBreaker.Architecture.GameStates.Gameplay;
using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Utilities.Patterns.State.Machines;

namespace BlockBreaker.Features.Player
{
    public class PlayerDefeatChecker
    {
        private readonly IStateMachine _gameplayStateMachine;
        private readonly PlayerData _player;

        public PlayerDefeatChecker(IStateMachine gameplayStateMachine, PlayerData player)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _player = player;
        }

        public void CheckDefeat()
        {
            if (_player.Size <= _player.Config.Size)
                _gameplayStateMachine.ChangeStateTo<DefeatGameplayState>();
        }
    }
}