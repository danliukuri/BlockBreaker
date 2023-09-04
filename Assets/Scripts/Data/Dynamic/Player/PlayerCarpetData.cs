using BlockBreaker.Data.Static.Configuration.Player.Carpet;
using BlockBreaker.Features.Player.Carpet;
using UnityEngine;

namespace BlockBreaker.Data.Dynamic.Player
{
    public class PlayerCarpetData
    {
        public PlayerCarpetConfig Config { get; set; }
        public Transform Transform { get; set; }

        public PlayerCarpetObstaclesDetector ObstaclesDetector { get; set; }
    }
}