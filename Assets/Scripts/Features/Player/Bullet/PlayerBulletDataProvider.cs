using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletDataProvider : MonoBehaviour
    {
        public PlayerBulletData Data { get; private set; }

        [Inject]
        public void Construct(PlayerBulletData data) => Data = data;
    }
}