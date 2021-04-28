using UnityEngine;
using SpaceShooter.Pooling;

namespace Asteroid
{
    public class AsteroidGenerator
    {
        private const float offset = 1f;
        private readonly float _minTimeToGenerate;
        private readonly float _maxTimeToGenerate;

        private readonly Camera _mainCamera;

        private float _timer = 0f;
        private float _randomTime;

        private readonly float _spawnMaxDistance;

        public AsteroidGenerator(Camera mainCamera, float asteroidsDistance, float minTime, float maxTime)
        {
            _mainCamera = mainCamera;
            _spawnMaxDistance = asteroidsDistance;

            _minTimeToGenerate = minTime;
            _maxTimeToGenerate = maxTime;

            RandomizeTime();
        }

        public void Tick(PoolingMachine pooling)
        {
            _timer += Time.deltaTime;

            if(_timer >= _randomTime)
            {
                RandomizeTime();
                _timer = 0f;

                Vector2 asteroidPosition = RandomizePosition();
                Asteroid pool = pooling.GetFromPool() as Asteroid;
                pool.SetPosition(asteroidPosition);
            }
        }

        private Vector2 RandomizePosition()
        {
            Vector2 leftBottom = _mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 rightTop = _mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

            bool side = Random.value > 0.5f;
            float xPosition;

            if (side)
                xPosition = Random.Range(leftBottom.x - _spawnMaxDistance - offset, leftBottom.x - offset);
            else
                xPosition = Random.Range(rightTop.x + offset, rightTop.x + _spawnMaxDistance + offset);

            float yPosition = Random.Range(leftBottom.y, rightTop.y);

            return new Vector2(xPosition, yPosition);
        }

        private void RandomizeTime()
        {
            _randomTime = Random.Range(_minTimeToGenerate, _maxTimeToGenerate);
        }
    }
}