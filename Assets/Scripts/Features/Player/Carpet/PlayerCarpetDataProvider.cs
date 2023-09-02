using BlockBreaker.Data.Static.Configuration.Player.Carpet;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Features.Player.Carpet
{
    public class PlayerCarpetDataProvider : MonoBehaviour
    {
        public PlayerCarpetConfig Config { get; private set; }

        [Inject]
        public void Construct(PlayerCarpetConfig playerCarpetConfig) => Config = playerCarpetConfig;
    }
}