using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelPuzzle.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;

        private PlayerData _save;

        public PlayerData Data
        {
            get => _data;
            set => _data = value;
        }

        private void Awake()
        {
            if (IsSessionExists())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
            }
        }

        public void Save()
        {
            
        }

        public void LoadLastSave()
        {
            
        }

        private bool IsSessionExists()
        {
            var sessions = FindObjectsOfType<GameSession>();
            foreach (var gameSession in sessions)
            {
                if (gameSession != this)
                {
                    return true;
                }
            }

            return false;
        }
        
    }
}