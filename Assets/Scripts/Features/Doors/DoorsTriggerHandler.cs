using BlockBreaker.Features.Player;
using UnityEngine;

namespace BlockBreaker.Features.Doors
{
    public class DoorsTriggerHandler : MonoBehaviour
    {
        private DoorsAnimationActivator _doorsAnimationActivator;

        private void Awake() => _doorsAnimationActivator = GetComponentInParent<DoorsAnimationActivator>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerDataProvider playerDataProvider))
                _doorsAnimationActivator.Open();
        }
    }
}