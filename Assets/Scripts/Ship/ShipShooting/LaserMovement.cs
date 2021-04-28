using UnityEngine;

namespace Ship.Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class LaserMovement : MonoBehaviour
    {
        [SerializeField] private float laserSpeed = 30f;
        private Rigidbody2D laserRigidbody;

        private void Awake()
        {
            laserRigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() => Move(transform.right, laserRigidbody, laserSpeed);

        public void Move(Vector2 direction, Rigidbody2D laserRigidbody, float laserSpeed)
        {
            Vector2 position = laserRigidbody.position;
            position += direction * laserSpeed * Time.deltaTime;
            laserRigidbody.MovePosition(position);
        }
    }
}