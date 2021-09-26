using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Pooling
{
    public abstract class PoolingMachine : MonoBehaviour
    {
        private readonly Queue<PoolObject> poolQueue = new Queue<PoolObject>();
        protected delegate PoolObject GetNewPool(GameObject associated);

        protected void PopulatePool(GameObject[] prefabs, int instancesQuantity, GetNewPool getPool, string folderName = "Pool")
        {
            GameObject parent = CreateParentFolder(folderName);

            for (int index = 0; index < instancesQuantity; index++)
            {
                int randomIndex = Random.Range(0, prefabs.Length);
                CreatePoolObject(prefabs[randomIndex], getPool, parent);
            }
        }

        protected void PopulatePool(GameObject prefab, int instancesQuantity, GetNewPool getPool, string folderName = "Pool")
        {
            GameObject parent = CreateParentFolder(folderName);

            for (int index = 0; index < instancesQuantity; index++)
                CreatePoolObject(prefab, getPool, parent);
        }

        public void ReturnToPool(PoolObject pool)
        {
            poolQueue.Enqueue(pool);
            pool.AssociatedGameObject.SetActive(false);
        }

        public PoolObject GetFromPool()
        {
            if (poolQueue.Count == 0)
                return null;

            PoolObject pool = poolQueue.Dequeue();
            pool.AssociatedGameObject.SetActive(true);
            return pool;
        }

        private static GameObject CreateParentFolder(string folderName)
        {
            GameObject parent = new GameObject($"[{folderName}Parent]");
            parent.transform.position = Vector3.zero;
            return parent;
        }
        
        private void CreatePoolObject(GameObject prefab, GetNewPool getPool, GameObject parent)
        {
            GameObject poolAssociated = Instantiate(prefab, parent.transform);
            PoolObject pool = getPool(poolAssociated);
            ReturnToPool(pool);
        }
    }
}