using UnityEngine;

namespace HealthSystem
{
    public abstract class Health : MonoBehaviour
    {
        [SerializeField] protected float maxHealth = 10f;
        protected float currentHealth = 10f;

        protected virtual void Awake()
        {
            RestoreHealth();
        }

        public virtual void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0f)
                Death();
        }

        protected virtual void RestoreHealth()
        {
            currentHealth = maxHealth;
        }

        protected abstract void Death();
    }
}
