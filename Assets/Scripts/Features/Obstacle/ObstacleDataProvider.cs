﻿using BlockBreaker.Data.Static.Configuration.Obstacle;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Features.Obstacle
{
    public class ObstacleDataProvider : MonoBehaviour
    {
        public ObstacleConfig Config { get; private set; }

        [Inject]
        public void Construct(ObstacleConfig obstacle) => Config = obstacle;
    }
}