using UnityEngine;

namespace PixelPuzzle.Components.Collectables
{
    public class ArmHeroComponent : MonoBehaviour
    {
        public void ArmHero(GameObject go)
        {
            var hero = go.GetComponent<Creatures.Hero.Hero>();
            if (hero != null)
            {
                hero.ArmHero();
            }
        }
    }
}