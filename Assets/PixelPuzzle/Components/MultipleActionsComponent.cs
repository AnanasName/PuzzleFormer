using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelPuzzle.Components
{
    public class MultipleActionsComponent : MonoBehaviour
    {
        [SerializeField] private int _actionsNeeded;
        [SerializeField] private UnityEvent _actionsCompleted;

        private int _actionsPerformed;
        private List<int> _actionsIds = new List<int>();

        public void ActionPerformed(GameObject target)
        {
            var itemId = target.GetInstanceID();
            if (!_actionsIds.Contains(itemId))
            {
                _actionsIds.Add(itemId);
                _actionsPerformed++;
                if (_actionsPerformed == _actionsNeeded)
                    _actionsCompleted?.Invoke();
            }
        }
    }
}