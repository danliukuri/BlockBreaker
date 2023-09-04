using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Features.Obstacle;
using BlockBreaker.Features.Player;
using BlockBreaker.Features.Player.Bullet;
using BlockBreaker.Features.Player.Carpet;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Utilities.Patterns.State;
using BlockBreaker.Utilities.Patterns.State.Machines;
using UnityEngine.Pool;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class SetupGameplayState : IEnterableState
    {
        private readonly IObjectPool<PlayerBulletDataProvider> _bulletsPool;
        private readonly IComponentConfigurator<ObstacleDataProvider> _obstacleConfigurator;
        private readonly ObstaclesProvider _obstaclesProvider;
        private readonly IObjectPool<PlayerCarpetDataProvider> _playerCarpetPool;
        private readonly IObjectPool<PlayerDataProvider> _playerPool;
        private readonly IStateMachine _gameplayStateMachine;

        public SetupGameplayState(IObjectPool<PlayerBulletDataProvider> bulletsPool,
            IComponentConfigurator<ObstacleDataProvider> obstacleConfigurator, ObstaclesProvider obstaclesProvider,
            IObjectPool<PlayerCarpetDataProvider> playerCarpetPool, IObjectPool<PlayerDataProvider> playerPool,
            IStateMachine gameplayStateMachine)
        {
            _bulletsPool = bulletsPool;
            _obstacleConfigurator = obstacleConfigurator;
            _obstaclesProvider = obstaclesProvider;
            _playerCarpetPool = playerCarpetPool;
            _playerPool = playerPool;
            _gameplayStateMachine = gameplayStateMachine;
        }

        public void Enter()
        {
            PlayerData player = _playerPool.Get().Data;
            PlayerCarpetData carpet = _playerCarpetPool.Get().Data;

            SetUpObstacles();
            SetUpPlayer(player, carpet);

            _gameplayStateMachine.ChangeStateTo<ProcessGameplayState>();
        }

        private void SetUpObstacles()
        {
            foreach (ObstacleDataProvider obstacle in _obstaclesProvider.ObstacleDataProviders)
                _obstacleConfigurator.Configure(obstacle);
            _obstaclesProvider.InitializeObstacleData();
        }

        private void SetUpPlayer(PlayerData player, PlayerCarpetData carpet)
        {
            player.SizeConverter = new PlayerSizeConverter(player);
            player.SizeCalculator = new PLayerSizeCalculator(carpet.ObstaclesDetector, player);
            player.SizeSetter = new PlayerSizeSetter(player);
            player.CarpetSizeSetter = new PlayerCarpetSizeSetter(carpet);
            player.Shooter = new PlayerBulletShooter(_bulletsPool, player);

            float newPlayerSize = player.SizeCalculator.CalculateSize(_obstaclesProvider.Obstacles);
            player.SizeSetter.Set(newPlayerSize);
            player.CarpetSizeSetter.Set(newPlayerSize);
        }
    }
}