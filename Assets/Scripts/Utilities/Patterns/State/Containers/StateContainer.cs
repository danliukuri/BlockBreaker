using System;
using System.Collections.Generic;
using BlockBreaker.Utilities.Patterns.State.Services;

namespace BlockBreaker.Utilities.Patterns.State.Containers
{
    public class StateContainer : IStateProvider, IStateRegistrar<IState>
    {
        private readonly Dictionary<Type, IState> _states = new();
        
        public void Register(IState state) => _states.Add(state.GetType(), state);
        
        public bool UnRegister(IState state) => _states.Remove(state.GetType());
        
        public TState Get<TState>() where TState : IState
        {
            Type stateType = typeof(TState);
            if (!_states.ContainsKey(stateType))
                throw new ArgumentException($"This state machine doesn't contains the '{stateType.Name}' state");
            return (TState)_states[stateType];
        }
    }
}