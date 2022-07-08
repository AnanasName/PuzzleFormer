using System.Collections;
using UnityEngine;

namespace PixelPuzzle.Creatures
{
    public abstract class Patrol : MonoBehaviour
    {
        public abstract IEnumerator DoPatrol();
    }
}