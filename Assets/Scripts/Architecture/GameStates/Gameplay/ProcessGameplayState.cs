using System.Collections.Specialized;
using System.Linq;
using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Features.Obstacle;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Utilities.Patterns.State;
using BlockBreaker.Utilities.Patterns.State.Machines;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class ProcessGameplayState : IEnterableState<PlayerCarpetData>, IExitableState
    {
        private readonly IStateMachine _gameplayStateMachine;
        private readonly ObstaclesProvider _obstaclesProvider;
        private readonly IActiveService[] _services;
        private PlayerCarpetData _carpet;

        public ProcessGameplayState(IStateMachine gameplayStateMachine, ObstaclesProvider obstaclesProvider,
            IActiveService[] services)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _obstaclesProvider = obstaclesProvider;
            _services = services;
        }

        public void Enter(PlayerCarpetData carpet)
        {
            _carpet = carpet;

            foreach (IActiveService service in _services)
                service.Enable();

            _obstaclesProvider.Obstacles.CollectionChanged += OnObstaclesCollectionChanged;
        }

        public void Exit()
        {
            foreach (IActiveService service in _services)
                service.Disable();

            _obstaclesProvider.Obstacles.CollectionChanged -= OnObstaclesCollectionChanged;
        }

        private void OnObstaclesCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            if (eventArgs.Action == NotifyCollectionChangedAction.Remove)
                if (!_carpet.ObstaclesDetector.DetectObstaclesOnCarpet(_obstaclesProvider.Obstacles).Any())
                    _gameplayStateMachine.ChangeStateTo<VictoryGameplayState>();
        }
    }
}