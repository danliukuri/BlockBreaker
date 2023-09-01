using BlockBreaker.Utilities.Patterns.State.Services;

namespace BlockBreaker.Utilities.Patterns.State.Machines
{
    public class StateMachine : IStateMachine
    {
        private readonly IStateProvider _stateProvider;
        private IState _currentState;

        public StateMachine(IStateProvider stateProvider) => _stateProvider = stateProvider;

        public void ChangeStateTo<TState>() where TState : IState
        {
            (_currentState as IExitableState)?.Exit();
            var newState = _stateProvider.Get<TState>();
            (newState as IEnterableState)?.Enter();
            _currentState = newState;
        }

        public void ChangeStateTo<TState, TEnterArgument>(TEnterArgument argument)
            where TState : IEnterableState<TEnterArgument>
        {
            (_currentState as IExitableState)?.Exit();
            var newState = _stateProvider.Get<TState>();
            newState.Enter(argument);
            _currentState = newState;
        }
    }
}