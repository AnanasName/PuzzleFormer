using PixelPuzzle.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelPuzzle.Components
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        
        public void Exit()
        {
            var session = FindObjectOfType<GameSession>();
            session.Save();
            SceneManager.LoadScene(_sceneName);
        } 
    }
}