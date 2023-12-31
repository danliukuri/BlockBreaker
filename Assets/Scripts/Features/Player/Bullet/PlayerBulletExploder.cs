﻿using System.Collections.Generic;
using System.Linq;
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

            ObstacleData[] obstaclesInExplosionRange = GetObstaclesInExplosionRange(bullet).ToArray();
            foreach (ObstacleData obstacle in obstaclesInExplosionRange)
                obstacle.Destroyer.Destroy(obstacle);

            bullet.Destroyer.Destroy(bulletProvider);
        }

        private IEnumerable<ObstacleData> GetObstaclesInExplosionRange(PlayerBulletData bullet)
        {
            return _obstaclesProvider.Obstacles.Where(IsInExplosionRange);

            bool IsInExplosionRange(ObstacleData obstacle)
            {
                float distanceToObstacle = Vector3.Distance(obstacle.Transform.position, bullet.Transform.position);
                float explosionRange = bullet.Config.ExplosionPower * bullet.Size;
                return distanceToObstacle <= explosionRange;
            }
        }
    }
}