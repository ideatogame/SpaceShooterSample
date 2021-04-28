using UnityEngine;
using MathPlus;
using System;
using HealthSystem;
using System.Collections;

namespace Asteroid
{
    public class AsteroidHealth : Health
    {
        public event EventHandler OnAsteroidDeath;
        public event EventHandler OnAsteroidOutOfView;

        [Header("Components")]
        [SerializeField] private Animator asteroidAnimator;

        [Header("Layers")]
        [SerializeField] private LayerMask cameraLayer;
        
        [Header("Parameters")]
        [SerializeField] private float timeToDestroy;
        [SerializeField] private string deathTrigger = "death";

        private Coroutine timerToRemove;
        private bool deathAnimationIsPlaying;
        private bool isAsteroidAnimatorNull = true;

        protected override void Awake()
        {
            isAsteroidAnimatorNull = asteroidAnimator == null;
            timerToRemove = StartCoroutine(RemoveOnSeconds());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareLayers(cameraLayer))
                return;
            
            StopCoroutine(timerToRemove);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareLayers(cameraLayer) || !enabled)
                return;
            
            timerToRemove = StartCoroutine(RemoveOnSeconds());
        }

        private IEnumerator RemoveOnSeconds()
        {
            yield return new WaitForSeconds(timeToDestroy);
            OutOfView();
        }
        
        private void OutOfView()
        {
            StopCoroutine(RemoveOnSeconds());
            RestoreHealth();
            OnAsteroidOutOfView?.Invoke(this, EventArgs.Empty);
        }

        public override void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if(currentHealth <= 0f && !deathAnimationIsPlaying)
                StartCoroutine(PlayAnimationAndDie());
        }

        private IEnumerator PlayAnimationAndDie()
        {
            deathAnimationIsPlaying = true;

            if (isAsteroidAnimatorNull)
            {
                Death();
                yield break;
            }

            AnimatorStateInfo info = asteroidAnimator.GetCurrentAnimatorStateInfo(0);
            asteroidAnimator.SetTrigger(deathTrigger);
            AnimatorStateInfo currentState = info;

            bool StateChanged() => AnimatorStateChanged(info, out currentState);
            yield return new WaitUntil(StateChanged);
            float duration = currentState.length;
            yield return new WaitForSeconds(duration);

            Death();
        }

        private bool AnimatorStateChanged(AnimatorStateInfo info, out AnimatorStateInfo current)
        {
            AnimatorStateInfo currentInfo = asteroidAnimator.GetCurrentAnimatorStateInfo(0);
            current = currentInfo;
            return info.shortNameHash != current.shortNameHash;
        }

        protected override void Death()
        {
            deathAnimationIsPlaying = false;
            
            RestoreHealth();
            StopCoroutine(RemoveOnSeconds());
            
            OnAsteroidDeath?.Invoke(this, EventArgs.Empty);
        }
    }
}