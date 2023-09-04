using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Infrastructure.Services.Input;

namespace BlockBreaker.Features.Player
{
    public class PlayerInputHandler : IActiveService
    {
        private readonly PlayerData _player;
        private readonly IPlayerTouchInputService _touchInputService;
        
        public PlayerInputHandler(PlayerData player, IPlayerTouchInputService touchInputService)
        {
            _player = player;
            _touchInputService = touchInputService;
        }

        public void Enable()
        {
            _touchInputService.OnTouchBegan += _player.Shooter.InstantiateBullet;
            _touchInputService.OnTouchEnded += _player.Shooter.ShootBullet;
            _touchInputService.OnTouchHold += _player.Shooter.ChargeBullet;
        }

        public void Disable()
        {
            _touchInputService.OnTouchBegan -= _player.Shooter.InstantiateBullet;
            _touchInputService.OnTouchEnded -= _player.Shooter.ShootBullet;
            _touchInputService.OnTouchHold -= _player.Shooter.ChargeBullet;
        }

        ~PlayerInputHandler() => Disable();
    }
}