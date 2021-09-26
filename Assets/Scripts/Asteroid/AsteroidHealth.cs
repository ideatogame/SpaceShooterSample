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
        [SerializeField] private Collider2D asteroidCollider;

        [Header("Layers")]
        [SerializeField] private LayerMask cameraLayer;
        
        [Header("Parameters")]
        [SerializeField] private float timeToDestroy;
        [SerializeField] private string deathTrigger = "death";


        protected override void Awake()
        {
            StartCoroutine(RemoveOnSeconds());
        }

        private void OnEnable()
        {
            asteroidCollider.enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareLayers(cameraLayer))
                return;
            
            StopAllCoroutines();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareLayers(cameraLayer) || !enabled)
                return;
            
            StartCoroutine(RemoveOnSeconds());
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

            if(currentHealth <= 0f)
                StartCoroutine(PlayAnimationAndDie());
        }

        private IEnumerator PlayAnimationAndDie()
        {
            asteroidCollider.enabled = false;
            asteroidAnimator.SetTrigger(deathTrigger);
            
            yield return new WaitForEndOfFrame();
            AnimatorStateInfo animatorStateInfo = asteroidAnimator.GetCurrentAnimatorStateInfo(0);
            float time = animatorStateInfo.length;
            
            yield return new WaitForSeconds(time);
            yield return new WaitForEndOfFrame();
            DisableAsteroid();
        }

        protected override void DisableAsteroid()
        {
            RestoreHealth();
            StopCoroutine(RemoveOnSeconds());
            
            OnAsteroidDeath?.Invoke(this, EventArgs.Empty);
        }
    }
}