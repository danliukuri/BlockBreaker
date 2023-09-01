using System;
using BlockBreaker.Utilities.Patterns.State.Services;
using Zenject;

namespace BlockBreaker.Utilities.Patterns.State.Containers
{
    public class StatesContainerInitializer : IInitializable, IDisposable
    {
        private readonly IStateRegistrar<IState> _stateContainer;
        private readonly IState[] _states;

        private StatesContainerInitializer(IStateRegistrar<IState> stateContainer, params IState[] states)
        {
            _stateContainer = stateContainer;
            _states = states;
        }

        public void Initialize()
        {
            foreach (IState state in _states)
                _stateContainer.Register(state);
        }

        public void Dispose()
        {
            foreach (IState state in _states)
                _stateContainer.UnRegister(state);
        }
    }
}