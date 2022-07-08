using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelPuzzle.Components.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private HealthChangedEvent _onHealthChanged;  

        public void ApplyDamage(int damageValue)
        {
            _health -= damageValue;
            _onHealthChanged?.Invoke(_health);
            _onDamage?.Invoke();
            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }

        public void ApplyHealth(int healthValue)
        {
            _health += healthValue;
            _onHealthChanged?.Invoke(_health);
            _onHeal?.Invoke();
        }

        public void SetHealth(int healthValue)
        {
            _health = healthValue;
        }


        [Serializable]
        public class HealthChangedEvent : UnityEvent<int>
        {
            
        }
    }
}
