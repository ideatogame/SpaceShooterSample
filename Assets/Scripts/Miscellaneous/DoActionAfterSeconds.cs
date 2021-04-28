using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Miscellaneous
{
    public class DoActionAfterSeconds : MonoBehaviour
    {
        [SerializeField] private float timeInSeconds = 1f;
        [SerializeField] private UnityEvent onTimeEnded;

        private bool timerHasStarted = false;

        public void StartTimer()
        {
            if(!timerHasStarted)
                StartCoroutine(InvokeUnityEventAfterSeconds(onTimeEnded, timeInSeconds));
        }

        private IEnumerator InvokeUnityEventAfterSeconds(UnityEvent unityEvent, float seconds)
        {
            timerHasStarted = true;
            yield return new WaitForSeconds(seconds);
            unityEvent?.Invoke();
            timerHasStarted = false;
        }
    }
}