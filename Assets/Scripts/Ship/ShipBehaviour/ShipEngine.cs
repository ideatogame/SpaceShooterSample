using UnityEngine;

namespace Ship.Behaviour
{
    public class ShipEngine : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody2D shipRigidbody;
        [SerializeField] private Animator shipAnimator;

        [Header("Parameters")]
        [SerializeField] private float movementForce = 10f;
        [SerializeField] private float rotationSpeed = 5f;

        private ShipRotation shipRotation;
        private ShipPosition shipPosition;
        private ShipAnimation shipAnimation;

        private Vector2 axis = Vector2.zero;

        private void Awake()
        {
            shipRotation = new ShipRotation(shipRigidbody);
            shipPosition = new ShipPosition(shipRigidbody, movementForce);
            shipAnimation = new ShipAnimation(shipAnimator);
        }

        private void Update()
        {
            CheckForInput();
            CheckForAnimation();
        }

        private void FixedUpdate()
        {
            shipRotation.RotateShip(axis.x, rotationSpeed);
            shipPosition.MoveShip(axis.y > 0f);
        }

        private void CheckForInput()
        {
            axis.x = Input.GetAxis("Horizontal");
            axis.y = Input.GetAxis("Vertical");
        }

        private void CheckForAnimation()
        {
            if (axis.y > 0f)
                shipAnimation.PlayAnimation();
            else
                shipAnimation.StopAnimation();
        }
    }
}