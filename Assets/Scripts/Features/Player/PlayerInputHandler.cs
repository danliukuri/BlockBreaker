using BlockBreaker.Features.Player.Bullet;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Infrastructure.Services.Input;
using UnityEngine;
using UnityEngine.Pool;

namespace BlockBreaker.Features.Player
{
    public class PlayerInputHandler : IActiveService
    {
        private readonly IObjectPool<PlayerBulletDataProvider> _bullets;
        private readonly IPlayerTouchInputService _touchInputService;

        private PlayerBulletDataProvider _currentBullet;

        public PlayerInputHandler(IObjectPool<PlayerBulletDataProvider> bullets,
            IPlayerTouchInputService touchInputService)
        {
            _bullets = bullets;
            _touchInputService = touchInputService;
        }

        ~PlayerInputHandler() => Disable();

        public void Enable()
        {
            _touchInputService.OnTouchBegan += InstantiateBullet;
            _touchInputService.OnTouchEnded += OnTouchEnded;
            _touchInputService.OnTouchHold += OnTouchHold;
        }

        public void Disable()
        {
            _touchInputService.OnTouchBegan -= InstantiateBullet;
            _touchInputService.OnTouchEnded -= OnTouchEnded;
            _touchInputService.OnTouchHold -= OnTouchHold;
        }

        private void InstantiateBullet() => _currentBullet = _bullets.Get();
        private void OnTouchEnded() { } // TODO: Shoot the bullet
        private void OnTouchHold() { }  // TODO: Convert player size to bullet
    }
}