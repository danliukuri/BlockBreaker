using BlockBreaker.Data.Static.Configuration.Obstacle;
using BlockBreaker.Features.Obstacle;
using UnityEngine;

namespace BlockBreaker.Data.Dynamic.Obstacle
{
    public class ObstacleData
    {
        public ObstacleConfig Config { get; set; }
        public Transform Transform { get; set; }
        public Collider Collider { get; set; }

        public ObstacleDestroyer Destroyer { get; set; }
        public IObstacleAnimationActivator AnimationActivator { get; set; }
    }
}