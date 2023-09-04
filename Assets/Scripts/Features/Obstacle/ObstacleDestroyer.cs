using BlockBreaker.Data.Dynamic.Obstacle;

namespace BlockBreaker.Features.Obstacle
{
    public class ObstacleDestroyer
    {
        private readonly ObstaclesProvider _obstaclesProvider;

        public ObstacleDestroyer(ObstaclesProvider obstaclesProvider) => _obstaclesProvider = obstaclesProvider;

        public void Destroy(ObstacleData obstacle)
        {
            _obstaclesProvider.Obstacles.Remove(obstacle);
            obstacle.Transform.gameObject.SetActive(false);
        }
    }
}