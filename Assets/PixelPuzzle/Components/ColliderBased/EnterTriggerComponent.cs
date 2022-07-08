﻿using System;
using System.Collections;
using System.Collections.Generic;
using PixelPuzzle.Components;
using PixelPuzzle.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace PixelPuzzle.Components.ColliderBased
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private EnterEvent _action;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.IsInLayer(_layer)) return;
            if (!string.IsNullOrEmpty(_tag))
            {
                if (!other.gameObject.CompareTag(_tag))
                    return;
            }

            _action?.Invoke(other.gameObject);
        }
    }
}