using UnityEngine;
using MathPlus;

namespace HealthSystem
{
    public class ApplyDamage : MonoBehaviour
    {
        [SerializeField] private float strength = 2f;
        [SerializeField] private LayerMask healthLayers;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareLayers(healthLayers))
                return;

            collision.GetComponent<Health>().TakeDamage(strength);
        }
    }
}