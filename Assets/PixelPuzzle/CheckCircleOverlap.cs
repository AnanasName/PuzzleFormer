using System;
using System.Linq;
using PixelPuzzle.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace PixelPuzzle
{
    public class CheckCircleOverlap : MonoBehaviour
    {
        [SerializeField] private float _radius = 1f;
        [SerializeField] private LayerMask _mask;
        [SerializeField] private string[] _tags;
        [SerializeField] private OnOverlapEvent _onOverlap;

        private readonly Collider2D[] _interactionResult = new Collider2D[10];

        private void OnDrawGizmosSelected()
        {
            Handles.color = HandlesUtils.TransparentRed;
            Handles.DrawSolidDisc(transform.position, Vector3.forward, _radius);
        }

        public void Check()
        {
            var size = Physics2D.OverlapCircleNonAlloc(
                transform.position,
                _radius,
                _interactionResult,
                _mask
            );

            for (var i = 0; i < size; i++)
            {
                var overlapResult = _interactionResult[i];
                if (_tags.Length > 0)
                {
                    var isInTags = _tags.Any(tag => overlapResult.CompareTag(tag));
                    if (isInTags)
                        _onOverlap?.Invoke(_interactionResult[i].gameObject);
                }

                else
                {
                    _onOverlap?.Invoke(_interactionResult[i].gameObject);
                }
            }
        }
    }

    [Serializable]
    public class OnOverlapEvent : UnityEvent<GameObject>
    {
    }
}