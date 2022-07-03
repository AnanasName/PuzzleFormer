using UnityEngine;

namespace PixelPuzzle.Components
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