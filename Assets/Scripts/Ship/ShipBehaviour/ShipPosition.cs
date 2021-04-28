using UnityEngine;

namespace Ship.Behaviour
{
    public class ShipPosition
    {
        private readonly Rigidbody2D _shipRigidbody;
        private readonly float _shipForce;

        public ShipPosition(Rigidbody2D shipRigidbody, float shipForce)
        {
            _shipRigidbody = shipRigidbody;
            _shipForce = shipForce;
        }

        public void MoveShip(bool moveButton)
        {
            if (!moveButton)
                return;

            Vector2 direction = _shipRigidbody.transform.right;
            Vector2 force = direction * _shipForce * Time.deltaTime;
            _shipRigidbody.AddForce(force);
        }
    }
}
