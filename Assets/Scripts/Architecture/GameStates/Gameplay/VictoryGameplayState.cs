using BlockBreaker.Utilities.Patterns.State;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class VictoryGameplayState : IEnterableState
    {
        public void Enter() => UnityEngine.Debug.Log("Victory");
    }
}