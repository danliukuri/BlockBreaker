using System.Collections.Generic;
using System.Linq;
using BlockBreaker.Data.Dynamic.Obstacle;
using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Features.Player.Carpet;

namespace BlockBreaker.Features.Player
{
    public class PLayerSizeCalculator
    {
        private readonly PlayerCarpetObstaclesDetector _carpetObstaclesDetector;
        private readonly PlayerData _player;

        public PLayerSizeCalculator(PlayerCarpetObstaclesDetector carpetObstaclesDetector, PlayerData player)
        {
            _carpetObstaclesDetector = carpetObstaclesDetector;
            _player = player;
        }

        public float CalculateSize(ICollection<ObstacleData> obstacles)
        {
            float lastPlayerSize;
            float currentPlayerSize = _player.Size;

            do
            {
                lastPlayerSize = currentPlayerSize;
                currentPlayerSize = CalculateNewSize(obstacles, currentPlayerSize);
            }
            while (lastPlayerSize < currentPlayerSize);

            return currentPlayerSize;
        }

        private float CalculateNewSize(IEnumerable<ObstacleData> obstacles, float lastPlayerSize)
        {
            IEnumerable<ObstacleData> obstaclesOnCarpet = 
                _carpetObstaclesDetector.DetectObstaclesOnCarpet(obstacles, lastPlayerSize / 2f);
            int obstaclesHealth = obstaclesOnCarpet.Sum(obstacle => obstacle.Config.HealthPoints);

            float playerSizeBoost = obstaclesHealth * _player.Config.HealthPointsToScaleRatio;
            return _player.Size + playerSizeBoost + playerSizeBoost * _player.Config.SizeReserveProportion;
        }
    }
}