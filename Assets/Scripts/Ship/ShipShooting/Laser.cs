using SpaceShooter.Pooling;
using UnityEngine;

namespace Ship.Shooting
{
    public class Laser : PoolObject
    {
        private readonly LaserDestroy laserDestroy;

        public Laser(PoolingMachine pooling, GameObject gameObject) : base(pooling, gameObject)
        {
            laserDestroy = gameObject.GetComponent<LaserDestroy>();
            laserDestroy.OnLaserDestroy += LaserDestroy_OnLaserDestroy;
        }

        private void LaserDestroy_OnLaserDestroy(object sender, System.EventArgs e)
        {
            ReturnToPool();
        }
    }
}