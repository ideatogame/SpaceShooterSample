using UnityEngine;

namespace Ship.Shooting
{
    public class LaserPositioning
    {
        private readonly Transform _shipTransform;
        private readonly Transform _leftLaserPoint;
        private readonly Transform _rightLaserPoint;

        public LaserPositioning(Transform leftPoint, Transform rightPoint, Transform shipTransform)
        {
            _leftLaserPoint = leftPoint;
            _rightLaserPoint = rightPoint;
            _shipTransform = shipTransform;
        }

        public void SetPosition(GameObject leftPool, GameObject rightPool)
        {
            leftPool.transform.position = _leftLaserPoint.transform.position;
            rightPool.transform.position = _rightLaserPoint.transform.position;

            float angle = _shipTransform.rotation.eulerAngles.z;
            Quaternion rotation = Quaternion.Euler(Vector3.forward * angle);

            leftPool.transform.rotation = rotation;
            rightPool.transform.rotation = rotation;
        }
    }
}