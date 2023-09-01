﻿namespace BlockBreaker.Utilities.Patterns.State.Services
{
    public interface IStateProvider
    {
        TState Get<TState>() where TState : IState;
    }
}