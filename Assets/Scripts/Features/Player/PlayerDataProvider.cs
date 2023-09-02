using BlockBreaker.Data.Static.Configuration.Player;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Features.Player
{
    public class PlayerDataProvider : MonoBehaviour
    {
        public PlayerConfig Config { get; private set; }

        [Inject]
        public void Construct(PlayerConfig playerConfig) => Config = playerConfig;
    }
}