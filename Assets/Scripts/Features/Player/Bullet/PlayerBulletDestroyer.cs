using UnityEngine.Pool;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletDestroyer
    {
        public IObjectPool<PlayerBulletDataProvider> BulletsPool { get; set; }

        public void Destroy(PlayerBulletDataProvider bullet)
        {
            BulletsPool?.Release(bullet);
            bullet.Data.IsDestroyed = true;
        }
    }
}