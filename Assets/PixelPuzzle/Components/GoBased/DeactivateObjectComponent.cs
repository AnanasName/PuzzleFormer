using UnityEngine;

namespace PixelPuzzle.Components.GoBased
{
    public class DeactivateObjectComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToDeactivate;

        public void DeactivateObject()
        {
            _objectToDeactivate.SetActive(false);
        }
    }
}