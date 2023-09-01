namespace BlockBreaker.Utilities.Patterns.State
{
    public interface IExitableState : IState
    {
        void Exit();
    }
}