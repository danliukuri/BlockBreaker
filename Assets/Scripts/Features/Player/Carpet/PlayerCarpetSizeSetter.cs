using BlockBreaker.Data.Dynamic.Player;
using UnityEngine;

namespace BlockBreaker.Features.Player.Carpet
{
    public class PlayerCarpetSizeSetter
    {
        private readonly PlayerCarpetData _carpet;

        public PlayerCarpetSizeSetter(PlayerCarpetData carpet) => _carpet = carpet;

        public void Set(float sizeX)
        {
            Vector3 localScale = _carpet.Transform.localScale;
            _carpet.Transform.localScale = new Vector3(sizeX, localScale.y, localScale.z);
            _carpet.Radius = new Vector3(sizeX / 2f, _carpet.Radius.y, _carpet.Radius.z);
        }
    }
}