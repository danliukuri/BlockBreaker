using UnityEngine;

namespace BlockBreaker.Utilities.Extensions.Unity
{
    public static class ResettingExtensions
    {
        public static void Reset(this Transform transform)
        {
            transform.position = default;
            transform.rotation = default;
            transform.localScale = default;
        }
        
        public static void Reset(this Rigidbody rigidbody)
        {
           rigidbody.velocity = default;
           rigidbody.angularVelocity = default;
           rigidbody.ResetInertiaTensor();
           rigidbody.ResetCenterOfMass();
        }
    }
}