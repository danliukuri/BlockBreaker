using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace BlockBreaker.Features.Player.Bullet
{
    public class PlayerBulletDestroyer
    {
        public IObjectPool<PlayerBulletDataProvider> BulletsPool { get; set; }
        
        public readonly CoroutineRunner _coroutineRunner;
        
        public PlayerBulletDestroyer(CoroutineRunner coroutineRunner) => _coroutineRunner = coroutineRunner;

        public void Destroy(PlayerBulletDataProvider bullet)
        {
            bullet.Data.IsDestroyed = true;
            BulletsPool?.Release(bullet);
            
            // bullet.Data.Collider.enabled = false;
            // bullet.Data.Rigidbody.isKinematic = true;
            // bullet.Data.AnimationActivator.Disappear();
            // _coroutineRunner.StartCoroutine(ReleaseBullet());
            //
            // IEnumerator ReleaseBullet()
            // {
            //     yield return new WaitForSeconds(bullet.Data.AnimationActivator.CurrentAnimationDuration);
            //     BulletsPool?.Release(bullet);
            // }
        }
    }
}