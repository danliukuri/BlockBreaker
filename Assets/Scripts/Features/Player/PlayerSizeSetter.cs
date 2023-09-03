using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;

namespace BlockBreaker.Features.Player
{
    public class PlayerSizeSetter
    {
        private readonly PlayerData _player;

        public PlayerSizeSetter(PlayerData player) => _player = player;

        public void Set(float size)
        {
            _player.Transform.localScale = Vector3.one * size;
            _player.Size = size;
            _player.Radius = size / 2f;
            CorrectPosition();
        }

        private void CorrectPosition()
        {
            Vector3 initialPosition = _player.InitialPosition;
            _player.Transform.position =
                new Vector3(initialPosition.x, initialPosition.y + _player.Radius, initialPosition.z);
        }
    }
}