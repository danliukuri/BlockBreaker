using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Infrastructure.Services.Input;

namespace BlockBreaker.Features.Player
{
    public class PlayerInputHandler : IActiveService
    {
        private readonly PlayerDefeatChecker _defeatChecker;
        private readonly PlayerData _player;
        private readonly IPlayerTouchInputService _touchInputService;
        private readonly PlayerVictoryChecker _victoryChecker;

        public PlayerInputHandler(PlayerDefeatChecker defeatChecker, PlayerData player,
            IPlayerTouchInputService touchInputService, PlayerVictoryChecker victoryChecker)
        {
            _defeatChecker = defeatChecker;
            _player = player;
            _touchInputService = touchInputService;
            _victoryChecker = victoryChecker;
        }

        public void Enable()
        {
            _touchInputService.OnTouchBegan += _player.Shooter.InstantiateBullet;
            _touchInputService.OnTouchEnded += _player.Shooter.ShootBullet;
            _touchInputService.OnTouchHold += _player.Shooter.ChargeBullet;

            _touchInputService.OnTouchEnded += _victoryChecker.CheckVictory;
            _touchInputService.OnTouchHold += _defeatChecker.CheckDefeat;
        }

        public void Disable()
        {
            _touchInputService.OnTouchBegan -= _player.Shooter.InstantiateBullet;
            _touchInputService.OnTouchEnded -= _player.Shooter.ShootBullet;
            _touchInputService.OnTouchHold -= _player.Shooter.ChargeBullet;

            _touchInputService.OnTouchEnded -= _victoryChecker.CheckVictory;
            _touchInputService.OnTouchHold -= _defeatChecker.CheckDefeat;
        }

        ~PlayerInputHandler() => Disable();
    }
}