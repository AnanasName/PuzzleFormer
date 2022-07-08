using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Animation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class MultiStateSpriteAnimation : MonoBehaviour
    {
        [SerializeField] private int _frameRate;
        [SerializeField] private SpriteAnimationState[] _spriteAnimationStates;
        [SerializeField] private UnityEvent _onComplete;
        
        private SpriteRenderer _renderer;
        private SpriteAnimationState _currentAnimationState;
        private float _secondsPerFrame;
        private int _currentSpriteIndex;
        private int _currentAnimationStateIndex;
        private float _nextFrameTime;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _secondsPerFrame = 1f / _frameRate;
            _nextFrameTime = Time.time + _secondsPerFrame;
            _currentAnimationState = _spriteAnimationStates[0];
            _currentSpriteIndex = 0;
            _currentAnimationStateIndex = 0;
        }

        private void Update()
        {
            if (_nextFrameTime > Time.time) return;

            if (_currentSpriteIndex >= _currentAnimationState.Sprites.Length)
            {
                if (_currentAnimationState.Loop)
                {
                    _currentSpriteIndex = 0;
                }
                else
                {
                    if (_currentAnimationState.AllowNextClip)
                    {
                        _currentAnimationStateIndex++;
                        _currentAnimationState = _spriteAnimationStates[_currentAnimationStateIndex];
                        _nextFrameTime += _secondsPerFrame;
                        _currentSpriteIndex = 0;
                    }
                    else
                    {
                        enabled = false;
                        _onComplete?.Invoke();
                        return;
                    }
                }
            }

            _renderer.sprite = _currentAnimationState.Sprites[_currentSpriteIndex];
            _nextFrameTime += _secondsPerFrame;
            _currentSpriteIndex++;
        }

        private void SetClip(string name)
        {
            var i = 0;
            foreach (var spriteAnimationState in _spriteAnimationStates)
            {
                if (spriteAnimationState.Name == name)
                {
                    _currentAnimationState = spriteAnimationState;
                    _nextFrameTime += _secondsPerFrame;
                    _currentSpriteIndex = 0;
                    _currentAnimationStateIndex = i;
                }

                i++;
            }
        }

        [Serializable]
        private class SpriteAnimationState
        {
            [SerializeField] private string name;
            [SerializeField] private Sprite[] _sprites;
            [SerializeField] private bool _loop;
            [SerializeField] private bool _allowNextClip;

            public string Name
            {
                get => name;
                set => name = value;
            }

            public Sprite[] Sprites
            {
                get => _sprites;
                set => _sprites = value;
            }

            public bool Loop
            {
                get => _loop;
                set => _loop = value;
            }

            public bool AllowNextClip
            {
                get => _allowNextClip;
                set => _allowNextClip = value;
            }
        }
    }
}