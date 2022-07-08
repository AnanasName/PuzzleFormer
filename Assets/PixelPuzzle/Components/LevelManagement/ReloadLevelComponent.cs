using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using PixelPuzzle.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelPuzzle.Components.LevelManagement
{
    public class ReloadLevelComponent : MonoBehaviour
    {

        public void Reload()
        {
            var session = FindObjectOfType<GameSession>();
            session.LoadLastSave();
            
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
