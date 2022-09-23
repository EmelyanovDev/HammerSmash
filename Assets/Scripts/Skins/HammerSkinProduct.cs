using Shop;
using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "HammerSkin")]
    
    public class HammerSkinProduct : Product
    {
        [SerializeField] private Mesh _hammerHead;
        [SerializeField] private Mesh _hammerStick;
        [SerializeField] private Material _hammerHeadMaterial;
        [SerializeField] private Material _hammerStickMaterial;
        [SerializeField] private Material _hammerHingeMaterial;

        public Mesh HammerHead => _hammerHead;
        public Mesh HammerStick => _hammerStick;
        public Material HammerHeadMaterial => _hammerHeadMaterial;
        public Material HammerStickMaterial => _hammerStickMaterial;
        public Material HammerHingeMaterial => _hammerHingeMaterial;
    }
}