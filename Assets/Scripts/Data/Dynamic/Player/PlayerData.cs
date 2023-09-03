using BlockBreaker.Data.Static.Configuration.Player;
using BlockBreaker.Features.Player;
using BlockBreaker.Features.Player.Carpet;
using UnityEngine;

namespace BlockBreaker.Data.Dynamic.Player
{
    public class PlayerData
    {
        public PlayerConfig Config { get; set; }
        public Transform Transform { get; set; }
        public Vector3 InitialPosition { get; set; }
        public float Size { get; set; }
        public float Radius { get; set; }

        public PLayerSizeCalculator SizeCalculator { get; set; }
        public PlayerSizeSetter SizeSetter { get; set; }
        public PlayerCarpetSizeSetter CarpetSizeSetter { get; set; }
    }
}