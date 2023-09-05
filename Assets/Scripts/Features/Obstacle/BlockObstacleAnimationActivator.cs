using UnityEngine;

namespace BlockBreaker.Features.Obstacle
{
    public class BlockObstacleAnimationActivator : IObstacleAnimationActivator
    {
        private readonly Animator _animator;

        public BlockObstacleAnimationActivator(Animator animator) => _animator = animator;

        public void Disappear() => _animator.SetTrigger(nameof(Disappear));
    }
}