using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Features.Player.Carpet
{
    public class PlayerCarpetDataProvider : MonoBehaviour
    {
        public PlayerCarpetData Data { get; private set; }

        [Inject]
        public void Construct(PlayerCarpetData data) => Data = data;
    }
}