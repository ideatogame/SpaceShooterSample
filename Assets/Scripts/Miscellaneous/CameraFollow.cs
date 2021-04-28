using UnityEngine;

namespace Miscellaneous
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smoothTime = 1f;
        [SerializeField] private float ppu = 32f;

        private Vector2 velocity;

        private void Update()
        {
            if (transform.position != target.position)
                FollowTransform(target);    
        }

        private void FollowTransform(Transform followedTarget)
        {
            Vector3 position = followedTarget.position;
            float x = Mathf.Round(position.x * ppu) / ppu;
            float y = Mathf.Round(position.y * ppu) / ppu;

            Vector2 newPosition = new Vector2(x, y);
            transform.position = Vector2.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        }
    }
}
