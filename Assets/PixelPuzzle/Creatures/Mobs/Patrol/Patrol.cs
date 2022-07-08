using System.Collections;
using UnityEngine;

namespace PixelPuzzle.Creatures.Mobs.Patrol
{
    public abstract class Patrol : MonoBehaviour
    {
        public abstract IEnumerator DoPatrol();
    }
}