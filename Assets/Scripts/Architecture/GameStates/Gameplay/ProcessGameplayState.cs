using System.Collections.Generic;
using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Utilities.Patterns.State;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class ProcessGameplayState : IEnterableState, IExitableState
    {
        private readonly List<IActiveService> _services;
        private PlayerCarpetData _carpet;

        public ProcessGameplayState(List<IActiveService> services) => _services = services;

        public void Enter() => _services.ForEach(service => service.Enable());

        public void Exit() => _services.ForEach(service => service.Disable());
    }
}