using BlockBreaker.Utilities.Patterns.State;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class DefeatGameplayState : IEnterableState
    {
        public void Enter() => UnityEngine.Debug.Log("Defeat");
    }
}