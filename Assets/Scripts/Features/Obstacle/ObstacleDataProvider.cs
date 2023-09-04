using BlockBreaker.Data.Dynamic.Obstacle;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Features.Obstacle
{
    public class ObstacleDataProvider : MonoBehaviour
    {
        public ObstacleData Data { get; private set; }

        [Inject]
        public void Construct(ObstacleData data) => Data = data;
    }
}