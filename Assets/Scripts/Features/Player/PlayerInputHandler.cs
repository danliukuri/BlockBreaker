using BlockBreaker.Data.Dynamic.Player;
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
        private readonly PlayerData _player;
        private readonly IPlayerTouchInputService _touchInputService;

        private PlayerBulletDataProvider _currentBullet;

        public PlayerInputHandler(IObjectPool<PlayerBulletDataProvider> bullets, PlayerData player,
            IPlayerTouchInputService touchInputService)
        {
            _bullets = bullets;
            _player = player;
            _touchInputService = touchInputService;
        }

        public void Enable()
        {
            _touchInputService.OnTouchBegan += InstantiateBullet;
            _touchInputService.OnTouchEnded += OnTouchEnded;
            _touchInputService.OnTouchHold += ConvertPlayerSizeToBullet;
        }

        public void Disable()
        {
            _touchInputService.OnTouchBegan -= InstantiateBullet;
            _touchInputService.OnTouchEnded -= OnTouchEnded;
            _touchInputService.OnTouchHold -= ConvertPlayerSizeToBullet;
        }

        ~PlayerInputHandler() => Disable();

        private void InstantiateBullet() => _currentBullet = _bullets.Get();
        private void OnTouchEnded() { } // TODO: Shoot the bullet

        private void ConvertPlayerSizeToBullet() => _player.SizeConverter.Convert(_currentBullet.Data,
            _currentBullet.Data.Config.CreationSpeed * Time.deltaTime);
    }
}