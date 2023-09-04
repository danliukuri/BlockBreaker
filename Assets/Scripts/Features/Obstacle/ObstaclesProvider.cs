using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BlockBreaker.Data.Dynamic.Obstacle;

namespace BlockBreaker.Features.Obstacle
{
    public class ObstaclesProvider
    {
        public IEnumerable<ObstacleDataProvider> ObstacleDataProviders { get; }
        public ObservableCollection<ObstacleData> Obstacles { get; private set; }

        public ObstaclesProvider(IEnumerable<ObstacleDataProvider> obstacleDataProviders) =>
            ObstacleDataProviders = obstacleDataProviders;

        public ObservableCollection<ObstacleData> InitializeObstacleData() =>
            Obstacles = new ObservableCollection<ObstacleData>(ObstacleDataProviders.Select(obstacle => obstacle.Data));
    }
}