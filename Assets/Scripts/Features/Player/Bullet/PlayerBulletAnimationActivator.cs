using UnityEngine;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletAnimationActivator
    {
        private readonly Animator _animator;
        private readonly int _layerIndex = default;

        public PlayerBulletAnimationActivator(Animator animator) => _animator = animator;

        public float CurrentAnimationDuration => _animator.GetCurrentAnimatorStateInfo(_layerIndex).length;

        public void Disappear() => _animator.SetTrigger(nameof(Disappear));

        public void Reset()
        {
            _animator.SetTrigger(nameof(Reset));
            _animator.ResetTrigger(nameof(Reset));
        }
    }
}