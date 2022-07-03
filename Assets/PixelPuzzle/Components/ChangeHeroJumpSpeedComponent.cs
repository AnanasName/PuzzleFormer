using System;
using System.Collections;
using UnityEngine;

namespace PixelPuzzle.Components
{
    public class ChangeHeroJumpSpeedComponent : MonoBehaviour
    {
        [SerializeField] private int _jumpSpeedMultipler;
        [SerializeField] private float _effectTime;

        private float _timeLeft;
        private Hero _hero;

        private void Awake()
        {
            _hero = FindObjectOfType<Hero>();
        }

        public void ChangeHeroJumpSpeed()
        {
            StartCoroutine(ChangeHeroJumpSpeedCoroutine());
        }

        private IEnumerator ChangeHeroJumpSpeedCoroutine()
        {
            _timeLeft = _effectTime;
            _hero.JumpSpeed *= _jumpSpeedMultipler;

            while (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                yield return null;
            }

            _hero.JumpSpeed = _hero.DefaultJumpSpeed;
        }
    }
}