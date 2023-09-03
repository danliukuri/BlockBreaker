using System.Collections.Generic;
using System.Linq;
using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Data.Static.Configuration.Player;
using BlockBreaker.Features.Obstacle;
using BlockBreaker.Features.Player.Carpet;
using UnityEngine;

namespace BlockBreaker.Features.Player
{
    public class PLayerSizeCalculator
    {
        private readonly PlayerCarpetDataProvider _playerCarpet;
        private readonly PlayerData _player;

        public PLayerSizeCalculator(PlayerData player, PlayerCarpetDataProvider playerCarpet)
        {
            _player = player;
            _playerCarpet = playerCarpet;
        }

        public float CalculateSize(ObstacleDataProvider[] obstacles)
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

        private float CalculateNewSize(IEnumerable<ObstacleDataProvider> obstacles, float lastPlayerSize)
        {
            float carpetRadiusX = lastPlayerSize / 2f;

            IEnumerable<ObstacleDataProvider> obstaclesOnWay = CalculateObstaclesOnWay(obstacles, carpetRadiusX);
            int obstaclesHealth = obstaclesOnWay.Sum(obstacle => obstacle.Config.HealthPoints);

            float playerSizeBoost = obstaclesHealth * _player.Config.HealthPointsToScaleRatio;
            return _player.Size + playerSizeBoost + playerSizeBoost * _player.Config.SizeReserveProportion;
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