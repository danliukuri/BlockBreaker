using System.Collections.Generic;
using System.Linq;
using BlockBreaker.Data.Static.Configuration.Player;
using BlockBreaker.Features.Obstacle;
using BlockBreaker.Features.Player.Carpet;
using UnityEngine;

namespace BlockBreaker.Features.Player
{
    public class PLayerSizeCalculator
    {
        private readonly PlayerCarpetDataProvider _playerCarpet;
        private readonly PlayerConfig _playerConfig;

        public PLayerSizeCalculator(PlayerConfig playerConfig, PlayerCarpetDataProvider playerCarpet)
        {
            _playerConfig = playerConfig;
            _playerCarpet = playerCarpet;
        }

        public float CalculateSize(ObstacleDataProvider[] obstacles)
        {
            float lastPlayerSize;
            float currentPlayerSize = _playerConfig.MinSize;
            
            do
            {
                lastPlayerSize = currentPlayerSize;
                currentPlayerSize = CalculateNewSize(obstacles, currentPlayerSize);
            }
            while (lastPlayerSize < currentPlayerSize);

            return currentPlayerSize;
        }

        private float CalculateNewSize(IEnumerable<ObstacleDataProvider> obstacles, float lastPlayerSize)
        {
            float carpetRadiusX = lastPlayerSize / 2f;

            IEnumerable<ObstacleDataProvider> obstaclesOnWay = CalculateObstaclesOnWay(obstacles, carpetRadiusX);
            int obstaclesHealth = obstaclesOnWay.Sum(obstacleProvider => obstacleProvider.Config.HealthPoints);

            float playerSizeBoost = obstaclesHealth * _playerConfig.HealthPointsToScaleRatio;
            return _playerConfig.MinSize + playerSizeBoost + playerSizeBoost * _playerConfig.SizeReserveProportion;
        }

        private IEnumerable<ObstacleDataProvider> CalculateObstaclesOnWay(IEnumerable<ObstacleDataProvider> obstacles,
            float carpetRadiusX)
        {
            Vector3 carpetPosition = _playerCarpet.transform.position;
            float carpetRadiusZ = _playerCarpet.Config.Radius.z;

            return obstacles.Where(obstacle => IsOnCarpet(obstacle.transform.position, obstacle.Config.Radius));

            bool IsOnCarpet(Vector3 point, Vector3 radius) =>
                Mathf.Abs(point.x) <= Mathf.Abs(carpetPosition.x) + carpetRadiusX + radius.x &&
                Mathf.Abs(point.z) <= Mathf.Abs(carpetPosition.z) + carpetRadiusZ + radius.z;
        }
    }
}