using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Utilities.Extensions.Unity;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletResetter : IComponentResetter<PlayerBulletDataProvider>
    {
        public void Reset(PlayerBulletDataProvider component)
        {
            PlayerBulletData bullet = component.Data;
            bullet.Transform.Reset();
            bullet.Rigidbody.Reset();
            bullet.IsDestroyed = false;
        }
    }
}