using System;
using System.Collections.Generic;
using BlockBreaker.Data.Dynamic.Obstacle;
using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Features.Obstacle;
using UnityEngine;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletExploder
    {
        private readonly ObstaclesProvider _obstaclesProvider;

        public PlayerBulletExploder(ObstaclesProvider obstaclesProvider) => _obstaclesProvider = obstaclesProvider;

        public void Explode(PlayerBulletDataProvider bulletProvider)
        {
            PlayerBulletData bullet = bulletProvider.Data;
            IEnumerable<ObstacleData> obstaclesInExplosionRange = GetObstaclesInExplosionRange(bullet);
            foreach (ObstacleData obstacle in obstaclesInExplosionRange)
                obstacle.Destroyer.Destroy(obstacle.Transform.gameObject);
            bullet.Destroyer.Destroy(bulletProvider);
        }

        private IEnumerable<ObstacleData> GetObstaclesInExplosionRange(PlayerBulletData bullet)
        {
            return Array.FindAll(_obstaclesProvider.Obstacles, IsInExplosionRange);

            bool IsInExplosionRange(ObstacleData obstacle)
            {
                float distanceToObstacle = Vector3.Distance(obstacle.Transform.position, bullet.Transform.position);
                float explosionRange = bullet.Config.ExplosionPower * bullet.Size;
                return distanceToObstacle <= explosionRange;
            }
        }
    }
}