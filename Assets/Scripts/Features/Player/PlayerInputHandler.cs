using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Infrastructure.Services.Input;
using UnityEngine;

namespace BlockBreaker.Features.Player
{
    public class PlayerInputHandler : IActiveService
    {
        private readonly IPlayerTouchInputService _touchInputService;

        public PlayerInputHandler(IPlayerTouchInputService touchInputService) => _touchInputService = touchInputService;

        ~PlayerInputHandler() => Disable();

        public void Enable()
        {
            _touchInputService.OnTouchBegan += OnTouchBegan;
            _touchInputService.OnTouchEnded += OnTouchEnded;
            _touchInputService.OnTouchHold += OnTouchHold;
        }

        public void Disable()
        {
            _touchInputService.OnTouchBegan -= OnTouchBegan;
            _touchInputService.OnTouchEnded -= OnTouchEnded;
            _touchInputService.OnTouchHold -= OnTouchHold;
        }

        private void OnTouchBegan() => Debug.Log("Touch began");
        private void OnTouchEnded() => Debug.Log("Touch ended");
        private void OnTouchHold() => Debug.Log("Touch hold");
    }
}