using UnityEngine;

namespace PixelPuzzle.Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _localSpawn = false;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var instance = Instantiate(_prefab, _target.position, Quaternion.identity);
            instance.transform.localScale = _target.lossyScale;
            if (_localSpawn)
            {
                instance.transform.parent = _target;
            }
            instance.SetActive(true);
        } 
    }
}   