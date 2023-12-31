﻿using BlockBreaker.Data.Dynamic.Obstacle;
using BlockBreaker.Data.Static.Configuration.Obstacle;
using BlockBreaker.Infrastructure.Services;
using UnityEngine;

namespace BlockBreaker.Features.Obstacle
{
    public class ObstacleConfigurator : IComponentConfigurator<ObstacleDataProvider>
    {
        private readonly ObstacleConfig _config;
        private readonly ObstacleDestroyer _obstacleDestroyer;

        public ObstacleConfigurator(ObstacleConfig config, ObstacleDestroyer obstacleDestroyer)
        {
            _obstacleDestroyer = obstacleDestroyer;
            _config = config;
        }

        public void Configure(ObstacleDataProvider component)
        {
            ObstacleData data = component.Data;
            data.Config = _config;
            data.Transform = component.transform;
            data.Collider = component.GetComponent<Collider>();
            data.Destroyer = _obstacleDestroyer;
            data.AnimationActivator = new BlockObstacleAnimationActivator(component.GetComponent<Animator>());
        }
    }
}