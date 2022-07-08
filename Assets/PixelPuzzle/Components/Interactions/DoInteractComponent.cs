using UnityEngine;

namespace PixelPuzzle.Components.Interactions
{
    public class DoInteractComponent : MonoBehaviour
    {
        public void DoInteraction(GameObject go)
        {
            var interactable = go.GetComponent<InteractableComponent>();
            if (interactable != null)
            {
                interactable.Interact();    
            }
        }
    }
}