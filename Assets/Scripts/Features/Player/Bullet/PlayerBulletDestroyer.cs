using UnityEngine.Pool;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletDestroyer
    {
        public IObjectPool<PlayerBulletDataProvider> BulletsPool { get; set; }

        public void Destroy(PlayerBulletDataProvider bullet)
        {
            bullet.Data.IsDestroyed = true;
            BulletsPool?.Release(bullet);
        }
    }
}