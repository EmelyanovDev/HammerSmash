using Shop;
using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "EnemySkin")]
    
    public class EnemySkinProduct : Product
    {
        [SerializeField] private GameObject _enemySkin;
    }
}