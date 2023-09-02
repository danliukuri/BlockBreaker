using BlockBreaker.Data.Static.Configuration.Player;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Features.Player
{
    public class PlayerDataProvider : MonoBehaviour
    {
        public PlayerConfig PlayerConfig { get; private set; }

        [Inject]
        public void Construct(PlayerConfig playerConfig) => PlayerConfig = playerConfig;
    }
}