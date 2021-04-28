using UnityEngine;

namespace MathPlus
{
    public static class LayerOperations
    {
        public static bool CompareLayers(this Collider2D collider, LayerMask otherLayer)
        {
            return CompareLayers(collider.gameObject.layer, otherLayer);
        }

        public static bool CompareLayers(this GameObject colliderObject, LayerMask otherLayer)
        {
            return CompareLayers(colliderObject.layer, otherLayer);
        }

        public static bool CompareLayers(int colliderLayer, LayerMask otherLayer)
        {
            return ((1 << colliderLayer) & otherLayer) != 0;
        }
    }
}
