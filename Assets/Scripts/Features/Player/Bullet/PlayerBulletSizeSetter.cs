using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletSizeSetter
    {
        public void Set(PlayerBulletData bullet, float size)
        {
            bullet.Size = size;
            bullet.Radius = size / 2f;
            bullet.Transform.localScale = Vector3.one * bullet.Size;
            
            CorrectPosition(bullet);
        }

        private void CorrectPosition(PlayerBulletData bullet)
        {
            Vector3 initialPosition = bullet.InitialPosition;
            bullet.Transform.localPosition =
                new Vector3(initialPosition.x, initialPosition.y + bullet.Radius, initialPosition.z);
        }
    }
}