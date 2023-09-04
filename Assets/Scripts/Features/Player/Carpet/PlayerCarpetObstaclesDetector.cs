using System.Collections.Generic;
using System.Linq;
using BlockBreaker.Data.Dynamic.Obstacle;
using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Utilities.Extensions.Unity;
using UnityEngine;

namespace BlockBreaker.Features.Player.Carpet
{
    public class PlayerCarpetObstaclesDetector
    {
        private readonly PlayerCarpetData _playerCarpet;

        public PlayerCarpetObstaclesDetector(PlayerCarpetData playerCarpet) => _playerCarpet = playerCarpet;

        public IEnumerable<ObstacleData> DetectObstaclesOnCarpet(IEnumerable<ObstacleData> obstacles,
            float playerRadius)
        {
            Vector3 carpetPosition = _playerCarpet.Transform.position;
            var carpetRadius = new Vector3(playerRadius, _playerCarpet.Config.Radius.y, _playerCarpet.Config.Radius.z);
        
            return obstacles.Where(obstacle =>
            {
                Vector3 obstaclePosition = obstacle.Transform.position;
                Vector3 obstacleRadius = obstacle.Config.Radius;
        
                return IsOnCarpet(obstaclePosition, obstacleRadius, carpetPosition, carpetRadius);
            });
        }

        public IEnumerable<ObstacleData> DetectObstaclesOnCarpet(IEnumerable<ObstacleData> obstacles) =>
            obstacles.Where(obstacle => IsOnCarpet(obstacle.Transform.position, obstacle.Config.Radius));

        private static bool IsOnCarpet(Vector3 objectPosition, Vector3 objectRadius,
            Vector3 carpetPosition, Vector3 carpetRadius) =>
            carpetPosition.IsInHorizontalBounds(carpetRadius, objectPosition, objectRadius);

        public bool IsOnCarpet(Vector3 objectPosition, Vector3 objectRadius) =>
            IsOnCarpet(objectPosition, objectRadius, _playerCarpet.Transform.position, _playerCarpet.Config.Radius);
    }
}