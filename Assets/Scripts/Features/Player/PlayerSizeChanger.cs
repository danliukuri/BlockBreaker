using System.Collections.Generic;
using System.Linq;
using BlockBreaker.Data.Static.Configuration.Player;
using BlockBreaker.Features.Obstacle;
using UnityEngine;

namespace BlockBreaker.Features.Player
{
    public class PlayerSizeChanger
    {
        private readonly Vector3 _initialPlayerPosition;

        private readonly Transform _player;
        private readonly PlayerConfig _playerConfig;

        public PlayerSizeChanger(Transform player, PlayerConfig playerConfig)
        {
            _player = player;
            _playerConfig = playerConfig;
            _initialPlayerPosition = _player.position;
        }

        public void IncreaseSize(IEnumerable<ObstacleDataProvider> obstacleProviders)
        {
            int obstaclesHealth = obstacleProviders.Sum(obstacleProvider => obstacleProvider.Obstacle.HealthPoints);
            float size = obstaclesHealth * _playerConfig.HealthPointsToScaleRatio;
            float radius = size / 2f;

            _player.localScale =
                _playerConfig.MinSize + Vector3.one * (size + size * _playerConfig.SizeReserveProportion);
            _player.position =
                new Vector3(_initialPlayerPosition.x, _initialPlayerPosition.y + radius, _initialPlayerPosition.z);
        }
    }
}