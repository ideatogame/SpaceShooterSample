using System;
using SpaceShooter.Pooling;
using UnityEngine;
using Stats;

namespace Asteroid
{
    public class Asteroid : PoolObject
    {
        private readonly AsteroidMovement asteroidMovement;

        public Asteroid(PoolingMachine pooling, GameObject gameObject, Transform playerTransform) : base(pooling, gameObject)
        {
            AsteroidHealth asteroidHealth = gameObject.GetComponent<AsteroidHealth>();
            asteroidMovement = gameObject.GetComponent<AsteroidMovement>();

            asteroidMovement.PlayerTransform = playerTransform;

            asteroidHealth.OnAsteroidDeath += RemoveAndAddScore;
            asteroidHealth.OnAsteroidOutOfView += Remove;
        }

        public void SetPosition(Vector2 position)
        {
            AssociatedGameObject.transform.position = position;
            asteroidMovement.SetNewPosition(position);
        }
        
        private void Remove(object sender, System.EventArgs e) => ReturnToPool();

        private void RemoveAndAddScore(object sender, System.EventArgs e)
        {
            Remove(this, EventArgs.Empty);
            GameStats.AddToAsteroidsDestroyed(1);
        }
    }
}