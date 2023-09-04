using UnityEngine;

namespace BlockBreaker.Features.Obstacle
{
    public class ObstacleDestroyer
    {
        public void Destroy(GameObject gameObject) => gameObject.SetActive(false);
    }
}