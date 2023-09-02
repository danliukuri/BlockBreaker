using UnityEngine;

namespace BlockBreaker.Features.Player.Carpet
{
    public class PlayerCarpetSizeChanger
    {
        private readonly Transform _carpet;

        public PlayerCarpetSizeChanger(Transform carpet) => _carpet = carpet;

        public void IncreaseSize(Vector3 playerScale)
        {
            Vector3 localScale = _carpet.localScale;
            _carpet.localScale = new Vector3(playerScale.x, localScale.y, localScale.z);
        }
    }
}