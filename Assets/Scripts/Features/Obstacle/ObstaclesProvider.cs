using System.Collections.Generic;
using System.Linq;
using BlockBreaker.Data.Dynamic.Obstacle;

namespace BlockBreaker.Features.Obstacle
{
    public class ObstaclesProvider
    {
        private readonly IEnumerable<ObstacleDataProvider> _obstacleDataProviders;
        public ObstacleData[] Obstacles { get; private set; }

        public ObstaclesProvider(IEnumerable<ObstacleDataProvider> obstacleDataProviders) =>
            _obstacleDataProviders = obstacleDataProviders;

        public ObstacleData[] InitializeObstacleData() =>
            Obstacles = _obstacleDataProviders.Select(obstacle => obstacle.Data).ToArray();
    }
}