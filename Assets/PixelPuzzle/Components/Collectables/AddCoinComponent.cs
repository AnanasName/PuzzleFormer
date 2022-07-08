using UnityEngine;

namespace PixelPuzzle.Components.Collectables
{
    public class AddCoinComponent : MonoBehaviour
    {
        [SerializeField] private int _numCoins;
        private Creatures.Hero.Hero _hero;

        private void Start()
        {
            _hero = FindObjectOfType<Creatures.Hero.Hero>();
        }

        public void Add()
        {
            _hero.AddCoins(_numCoins);
        }
    }
}