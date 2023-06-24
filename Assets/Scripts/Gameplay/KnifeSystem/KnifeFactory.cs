using UnityEngine;

namespace Gameplay.KnifeSystem
{
    public class KnifeFactory
    {
        private readonly GameObject _knifePrefab;

        public KnifeFactory(GameObject prefab)
        {
            _knifePrefab = prefab;
        }
        
        public GameObject CreateKnife(Vector3 position)
        {
            return Object.Instantiate(_knifePrefab, position, Quaternion.identity);
        }
    }
}