using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Miscellaneous
{
    public class DoActionOnStart : MonoBehaviour
    {
        [SerializeField] private UnityEvent onStart;

        private void Start() => onStart?.Invoke();
    }
}
