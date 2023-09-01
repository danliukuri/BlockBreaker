using System;
using System.Collections.Generic;
using BlockBreaker.Architecture.GameStates.Gameplay;
using BlockBreaker.Utilities.Patterns.State.Containers;
using BlockBreaker.Utilities.Patterns.State.Machines;
using Zenject;

namespace BlockBreaker.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class GameplayBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindStatesContainer();
            BindStates();
        }

        private void BindStateMachine() => Container.BindInterfacesTo<StateMachine>().AsSingle();

        private void BindStatesContainer()
        {
            Container
                .BindInterfacesTo<StateContainer>()
                .AsSingle()
                .WhenInjectedInto(typeof(StateMachine), typeof(StatesContainerInitializer));

            Container.BindInterfacesTo<StatesContainerInitializer>().AsSingle();
        }

        private void BindStates()
        {
            var gameStatesTypes = new List<Type> { typeof(SetupGameplayState) };
            gameStatesTypes.ForEach(BindState());

            Action<Type> BindState() => stateType =>
                Container.BindInterfacesTo(stateType).AsSingle().WhenInjectedInto<StatesContainerInitializer>();
        }
    }
}