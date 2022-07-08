using System;
using System.Collections;
using PixelPuzzle.Components.ColliderBased;
using UnityEngine;

namespace PixelPuzzle.Creatures.Mobs.Patrol
{
    public class PlatformPatrol : Patrol
    {
        [SerializeField] private FastLayerCheck _platformCheck;

        private Creature _creature;
        private int _multipler = -1;

        private void Awake()
        {
            _creature = GetComponent<Creature>();
        }

        public override IEnumerator DoPatrol()
        {
            while (enabled)
            {

                if (!_platformCheck.IsTouchingLayer)
                {
                    _multipler *= -1;
                }
                
                var direction = new Vector2(_multipler*1, 0);
                _creature.SetDirection(direction);
                
                yield return null;
            }
        }
    }
}