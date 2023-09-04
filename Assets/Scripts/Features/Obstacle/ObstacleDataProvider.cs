using BlockBreaker.Data.Dynamic.Obstacle;
using BlockBreaker.Data.Static.Configuration.Obstacle;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Features.Obstacle
{
    public class ObstacleDataProvider : MonoBehaviour
    {
        public ObstacleData Data { get; private set; }

        [Inject]
        public void Construct(ObstacleData data, ObstacleConfig config)
        {
            Data = data;
            Data.Config = config;
            Data.Transform = transform;
            Data.Destroyer = new ObstacleDestroyer();
        }
    }
}