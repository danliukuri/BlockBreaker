using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;

namespace BlockBreaker.Features.Player
{
    public class PlayerMover
    {
        private readonly PlayerData _player;

        public PlayerMover(PlayerData player) => _player = player;

        public void Move()
        {
            Vector3 movingForce = _player.Config.GoalDirection * _player.Config.MovingForce;
            Vector3 jumpingForce = _player.Transform.up * _player.Config.JumpingForce;
            _player.Rigidbody.AddForce(movingForce + jumpingForce, ForceMode.Impulse);
        }
    }
}