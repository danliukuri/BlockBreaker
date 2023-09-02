using UnityEngine;

namespace BlockBreaker.Features.Player
{
    public class PlayerSizeSetter
    {
        private readonly Transform _player;

        public PlayerSizeSetter(Transform player) => _player = player;

        public void Set(float size)
        {
            _player.localScale = Vector3.one * size;
            CorrectPosition(size);
        }

        private void CorrectPosition(float size)
        {
            Vector3 playerPosition = _player.position;
            float radius = size / 2f;
            _player.position = new Vector3(playerPosition.x, playerPosition.y + radius, playerPosition.z);
        }
    }
}