using System.Collections.Specialized;
using System.Linq;
using BlockBreaker.Architecture.GameStates.Gameplay;
using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Features.Obstacle;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Utilities.Patterns.State.Machines;

namespace BlockBreaker.Features.Player
{
    public class PlayerVictoryChecker : IActiveService
    {
        private readonly PlayerCarpetData _carpet;
        private readonly IStateMachine _gameplayStateMachine;
        private readonly ObstaclesProvider _obstaclesProvider;

        public PlayerVictoryChecker(PlayerCarpetData carpet, IStateMachine gameplayStateMachine,
            ObstaclesProvider obstaclesProvider)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _obstaclesProvider = obstaclesProvider;
            _carpet = carpet;
        }

        public void Enable() => _obstaclesProvider.Obstacles.CollectionChanged += OnObstaclesCollectionChanged;

        public void Disable() => _obstaclesProvider.Obstacles.CollectionChanged -= OnObstaclesCollectionChanged;

        private void OnObstaclesCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            if (eventArgs.Action == NotifyCollectionChangedAction.Remove)
                CheckVictory();
        }

        public void CheckVictory()
        {
            if (!_carpet.ObstaclesDetector.DetectObstaclesOnCarpet(_obstaclesProvider.Obstacles).Any())
                _gameplayStateMachine.ChangeStateTo<VictoryGameplayState>();
        }
    }
}