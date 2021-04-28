using UnityEngine;
using MathPlus;
using System;

namespace Ship.Shooting
{
    public class LaserDestroy : MonoBehaviour
    {
        public event EventHandler OnLaserDestroy;

        [SerializeField] private LayerMask asteroidLayer;
        [SerializeField] private float timeToDestroy = 2f;

        private float _timer = 0f;

        private void Update() => TimerTick(timeToDestroy);

        private void OnTriggerEnter2D(Collider2D collider)
        {
            AsteroidCollision(collider);
        }

        public void TimerTick(float destroyTime)
        {
            _timer += Time.deltaTime;

            if(_timer >= destroyTime)
                RemoveLaser();
        }

        public void AsteroidCollision(Collider2D collider)
        {
            if (!collider.CompareLayers(asteroidLayer))
                return;

            RemoveLaser();
        }

        private void RemoveLaser()
        {
            _timer = 0f;
            OnLaserDestroy?.Invoke(this, EventArgs.Empty);
        }
    }
}