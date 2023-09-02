using UnityEngine;

namespace BlockBreaker.Features.Player.Carpet
{
    public class PlayerCarpetSizeSetter
    {
        private readonly Transform _carpet;

        public PlayerCarpetSizeSetter(Transform carpet) => _carpet = carpet;

        public void Set(float sizeX)
        {
            Vector3 localScale = _carpet.localScale;
            _carpet.localScale = new Vector3(sizeX, localScale.y, localScale.z);
        }
    }
}