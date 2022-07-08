using UnityEngine;

namespace PixelPuzzle.Components.GoBased
{
    public class SpawnCoinsComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] _coinsPrefabs;

        public void Spawn()
        {
            var target = gameObject.transform;
            var coinIndex = Random.Range(0, _coinsPrefabs.Length);
            var instance = Instantiate(_coinsPrefabs[coinIndex], target.position, Quaternion.identity);
            instance.transform.localScale = target.lossyScale; 
        }
    }
}