using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Features.Player
{
    public class PlayerDataProvider : MonoBehaviour
    {
        public PlayerData Data { get; private set; }

        [Inject]
        public void Construct(PlayerData data) => Data = data;
    }
}