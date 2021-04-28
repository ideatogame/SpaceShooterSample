using SpaceShooter.Pooling;
using UnityEngine;

namespace Asteroid
{
    public class AsteroidSpawner : PoolingMachine
    {
        [Header("Components")]
        [SerializeField] private GameObject[] asteroidPrefabs;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Transform playerTransform;

        [Header("Parameters")]
        [SerializeField] private int asteroidsQuantity = 10;
        [SerializeField] private float asteroidsDistance = 10f;
        [SerializeField] private float minTime, maxTime;

        private AsteroidGenerator asteroidGenerator;

        private void Awake()
        {
            asteroidGenerator = new AsteroidGenerator(mainCamera, asteroidsDistance, minTime, maxTime);
            PopulatePool(asteroidPrefabs, asteroidsQuantity, CreateNewAsteroid, "Asteroid");
        }

        private void Update()
        {
            asteroidGenerator.Tick(this);
        }

        private PoolObject CreateNewAsteroid(GameObject associated)
        {
            Asteroid newAsteroid = new Asteroid(this, associated, playerTransform);
            return newAsteroid;
        }
    }
}