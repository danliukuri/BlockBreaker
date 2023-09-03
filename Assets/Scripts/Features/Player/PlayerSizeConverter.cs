using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Features.Player.Bullet;

namespace BlockBreaker.Features.Player
{
    public class PlayerSizeConverter
    {
        private readonly PlayerData _player;
        private readonly PlayerBulletSizeSetter _bulletSizeSetter = new();

        public PlayerSizeConverter(PlayerData player) => _player = player;

        public void Convert(PlayerBulletData bullet, float sizeAmount)
        {
            _player.SizeSetter.Set(_player.Size - sizeAmount);
            _player.CarpetSizeSetter.Set(_player.Size);
            
            _bulletSizeSetter.Set(bullet, bullet.Size + sizeAmount);
        }
    }
}