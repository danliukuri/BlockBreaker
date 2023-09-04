using System.Collections.Generic;
using System.Linq;
using BlockBreaker.Data.Dynamic.Obstacle;

namespace BlockBreaker.Features.Obstacle
{
    public class ObstaclesProvider
    {
        public IEnumerable<ObstacleDataProvider> ObstacleDataProviders { get; }
        public ObstacleData[] Obstacles { get; private set; }

        public ObstaclesProvider(IEnumerable<ObstacleDataProvider> obstacleDataProviders) =>
            ObstacleDataProviders = obstacleDataProviders;

        public ObstacleData[] InitializeObstacleData() =>
            Obstacles = ObstacleDataProviders.Select(obstacle => obstacle.Data).ToArray();
    }
}