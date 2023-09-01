using BlockBreaker.Architecture.GameStates.Gameplay;
using BlockBreaker.Utilities.Patterns.State.Machines;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Architecture.Bootstrap
{
    public class SceneBootstrapper : MonoBehaviour
    {
        private IStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IStateMachine gameStateMachine) => _gameStateMachine = gameStateMachine;

        private void Start() => _gameStateMachine.ChangeStateTo<SetupGameplayState>();
    }
}