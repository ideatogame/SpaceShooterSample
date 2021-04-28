using SpaceShooter.Pooling;
using UnityEngine;

namespace Ship.Shooting
{
    public class ShipWeapon : PoolingMachine
    {
        [Header("Pooling")]
        [SerializeField] private GameObject laserPrefab;
        [SerializeField] private int instancesQuantity = 30;

        [Header("Laser Points")]
        [SerializeField] private Transform leftLaserPoint;
        [SerializeField] private Transform rightLaserPoint;

        private LaserPositioning laserPositioning;

        private void Awake()
        {
            PopulatePool(laserPrefab, instancesQuantity, CreateNewLaser, "Laser");
            laserPositioning = new LaserPositioning(leftLaserPoint, rightLaserPoint, transform);
        }

        private void Update() => Shoot();

        private PoolObject CreateNewLaser(GameObject associated)
        {
            Laser newLaser = new Laser(this, associated);
            return newLaser;
        }

        private void Shoot()
        {
            if(!Input.GetKeyDown(KeyCode.Space))
                return;

            PoolObject leftLaser = GetFromPool();
            PoolObject rightLaser = GetFromPool();

            laserPositioning.SetPosition(leftLaser.AssociatedGameObject, rightLaser.AssociatedGameObject);
        }
    }
}