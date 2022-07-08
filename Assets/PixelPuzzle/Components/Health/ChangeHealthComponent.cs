using UnityEngine;

namespace PixelPuzzle.Components.Health
{
    public class ChangeHealthComponent : MonoBehaviour
    {
        [SerializeField] private int _changeHealthValue;

        public void ChangeHealth(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null)
            {
                if (_changeHealthValue >= 0)
                {
                    healthComponent.ApplyHealth(_changeHealthValue);
                }
                else
                {
                    healthComponent.ApplyDamage(-_changeHealthValue);
                }
            } 
        }
    }
}
