using UnityEngine;

namespace BlockBreaker.Utilities.Extensions.Unity
{
    public static class VectorExtensions
    {
        public static bool IsInHorizontalBounds(this Vector3 firstPoint, Vector3 firstRadius,
            Vector3 secondPoint, Vector3 secondRadius) =>
            Mathf.Abs(secondPoint.x) <= Mathf.Abs(firstPoint.x) + firstRadius.x + secondRadius.x &&
            Mathf.Abs(secondPoint.z) <= Mathf.Abs(firstPoint.z) + firstRadius.z + secondRadius.z;
    }
}