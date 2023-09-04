using BlockBreaker.Features.Obstacle;
using UnityEngine;

namespace BlockBreaker.Features.Player.Bullet
{
    [RequireComponent(typeof(PlayerBulletDataProvider))]
    public class PlayerBulletCollisionHandler : MonoBehaviour
    {
        private PlayerBulletDataProvider _bulletProvider;

        private void Awake() => _bulletProvider = GetComponent<PlayerBulletDataProvider>();

        private void OnCollisionEnter(Collision other)
        {
            if(!_bulletProvider.Data.IsDestroyed)
                if (other.gameObject.TryGetComponent(out ObstacleDataProvider obstacleProvider))
                    _bulletProvider.Data.Exploder.Explode(_bulletProvider);
        }
    }
}