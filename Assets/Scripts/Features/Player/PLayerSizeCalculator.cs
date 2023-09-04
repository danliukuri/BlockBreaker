using System.Collections.Generic;
using System.Linq;
using BlockBreaker.Data.Dynamic.Obstacle;
using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;

namespace BlockBreaker.Features.Player
{
    public class PLayerSizeCalculator
    {
        private readonly PlayerData _player;
        private readonly PlayerCarpetData _playerCarpet;

        public PLayerSizeCalculator(PlayerData player, PlayerCarpetData playerCarpet)
        {
            _playerCarpet = playerCarpet;
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
            float carpetRadiusX = lastPlayerSize / 2f;

            IEnumerable<ObstacleData> obstaclesOnWay = CalculateObstaclesOnWay(obstacles, carpetRadiusX);
            int obstaclesHealth = obstaclesOnWay.Sum(obstacle => obstacle.Config.HealthPoints);

            float playerSizeBoost = obstaclesHealth * _player.Config.HealthPointsToScaleRatio;
            return _player.Size + playerSizeBoost + playerSizeBoost * _player.Config.SizeReserveProportion;
        }

        private IEnumerable<ObstacleData> CalculateObstaclesOnWay(IEnumerable<ObstacleData> obstacles,
            float carpetRadiusX)
        {
            Vector3 carpetPosition = _playerCarpet.Transform.position;
            float carpetRadiusZ = _playerCarpet.Config.Radius.z;

            return obstacles.Where(obstacle => IsOnCarpet(obstacle.Transform.position, obstacle.Config.Radius));

            bool IsOnCarpet(Vector3 point, Vector3 radius) =>
                Mathf.Abs(point.x) <= Mathf.Abs(carpetPosition.x) + carpetRadiusX + radius.x &&
                Mathf.Abs(point.z) <= Mathf.Abs(carpetPosition.z) + carpetRadiusZ + radius.z;
        }
    }
}