using System.Collections.Generic;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Utilities.Patterns.State;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class ProcessGameplayState : IEnterableState
    {
        private readonly IEnumerable<IActiveService> _services;

        public ProcessGameplayState(IEnumerable<IActiveService> services) => _services = services;

        public void Enter()
        {
            foreach (IActiveService service in _services)
                service.Enable();
        }
    }
}