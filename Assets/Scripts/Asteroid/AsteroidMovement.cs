using Ship.Behaviour;
using UnityEngine;

namespace Asteroid
{
    public class AsteroidMovement : MonoBehaviour
    {
        public Transform PlayerTransform { private get; set; }

        [SerializeField] private float _asteroidSpeed;

        private int direction = 1;
        private Rigidbody2D _asteroidRigidbody;

        private void Awake()
        {
            if (PlayerTransform == null)
            {
                PlayerTransform = FindObjectOfType<ShipEngine>().transform;

                if (PlayerTransform == null)
                    enabled = false;
            }

            _asteroidRigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetNewPosition(Vector2 position)
        {
            transform.position = position;
            CalculateDirection(position, PlayerTransform.position);

            Vector3 newRotation = transform.rotation.eulerAngles;
            newRotation.z = Random.Range(-10f, 10f);
            transform.rotation = Quaternion.Euler(newRotation);
        }

        private void CalculateDirection(Vector2 from, Vector2 to)
        {
            direction = (to.x > from.x) ? 1 : -1;
        }

        private void FixedUpdate()
        {
            Vector2 position = transform.position;
            position += (Vector2)transform.right * direction * _asteroidSpeed * Time.deltaTime;
            _asteroidRigidbody.MovePosition(position);
        }
    }
}