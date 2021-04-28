using UnityEngine;

namespace SpaceShooter.Pooling
{
    public abstract class PoolObject
    {
        public GameObject AssociatedGameObject => associatedGameObject;

        protected PoolingMachine machine;
        protected GameObject associatedGameObject;

        protected PoolObject(PoolingMachine pooling, GameObject gameObject)
        {
            associatedGameObject = gameObject;
            machine = pooling;
        }

        protected virtual void ReturnToPool() => machine.ReturnToPool(this);
    }
}