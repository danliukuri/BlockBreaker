using UnityEngine;

namespace BlockBreaker.Features.Doors
{
    [RequireComponent(typeof(Animator))]
    public class DoorsAnimationActivator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake() => _animator = GetComponent<Animator>();

        public void Open() => _animator.SetTrigger(nameof(Open));
    }
}