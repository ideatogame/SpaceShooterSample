using UnityEngine;

namespace Ship.Behaviour
{
    public class ShipRotation
    {
        private readonly Rigidbody2D _shipRigidbody;

        public ShipRotation(Rigidbody2D shipRigidbody)
        {
            _shipRigidbody = shipRigidbody;
        }

        public void RotateShip(float horizontal, float speed)
        {
            float angle = _shipRigidbody.transform.rotation.eulerAngles.z;
            angle -= horizontal * speed * Time.deltaTime;
            _shipRigidbody.MoveRotation(angle);
        }
    }
}