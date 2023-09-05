using BlockBreaker.Features.UI;
using BlockBreaker.Utilities.Patterns.State;
using UnityEngine.Pool;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class DefeatGameplayState : IEnterableState
    {
        private readonly IObjectPool<DefeatTextMarker> _defeatTexts;

        public DefeatGameplayState(IObjectPool<DefeatTextMarker> defeatTexts) => _defeatTexts = defeatTexts;

        public void Enter() => _defeatTexts.Get();
    }
}