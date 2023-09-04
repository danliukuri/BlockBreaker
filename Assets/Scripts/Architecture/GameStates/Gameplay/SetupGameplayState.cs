using BlockBreaker.Data.Dynamic.Player;
using BlockBreaker.Features.Obstacle;
using BlockBreaker.Features.Player;
using BlockBreaker.Features.Player.Bullet;
using BlockBreaker.Features.Player.Carpet;
using BlockBreaker.Infrastructure.Services;
using BlockBreaker.Utilities.Patterns.State;
using UnityEngine.Pool;

namespace BlockBreaker.Architecture.GameStates.Gameplay
{
    public class SetupGameplayState : IEnterableState
    {
        private readonly ObstaclesProvider _obstaclesProvider;
        private readonly IObjectPool<PlayerCarpetDataProvider> _playerCarpetPool;
        private readonly IObjectPool<PlayerDataProvider> _playerPool;
        private readonly IActiveService[] _services;

        public SetupGameplayState(ObstaclesProvider obstaclesProvider,
            IObjectPool<PlayerCarpetDataProvider> playerCarpetPool, IObjectPool<PlayerDataProvider> playerPool,
            IActiveService[] services)
        {
            _obstaclesProvider = obstaclesProvider;
            _playerCarpetPool = playerCarpetPool;
            _playerPool = playerPool;
            _services = services;
        }

        public void Enter()
        {
            PlayerDataProvider player = _playerPool.Get();
            PlayerCarpetDataProvider carpet = _playerCarpetPool.Get();

            _obstaclesProvider.InitializeObstacleData();
            SetUpPlayer(player.Data, carpet);

            foreach (IActiveService service in _services)
                service.Enable();
        }

        private void SetUpPlayer(PlayerData player, PlayerCarpetDataProvider carpet)
        {
            player.SizeConverter = new PlayerSizeConverter(player);
            player.SizeCalculator = new PLayerSizeCalculator(player, carpet);
            player.SizeSetter = new PlayerSizeSetter(player);
            player.CarpetSizeSetter = new PlayerCarpetSizeSetter(carpet.transform);
            player.Shooter = new PlayerBulletShooter(player);

            float newPlayerSize = player.SizeCalculator.CalculateSize(_obstaclesProvider.Obstacles);
            player.SizeSetter.Set(newPlayerSize);
            player.CarpetSizeSetter.Set(newPlayerSize);
        }
    }
}