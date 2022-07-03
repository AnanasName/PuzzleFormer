using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace PixelPuzzle.Components
{
    public class InvokeActionByTime : MonoBehaviour
    {
        [SerializeField] private float _timeToInvoke;
        [SerializeField] private UnityEvent _event;

        private float _timeLeft;

        public void SetTimeToAction()
        {
            StartCoroutine(WaitForInvocation());
        }

        private IEnumerator WaitForInvocation()
        {
            _timeLeft = _timeToInvoke;

            while (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                yield return null;
            }
            
            _event?.Invoke();
        }
    }
}