using Skins;
using UnityEngine;

namespace Hammer
{
    public class HammerSkin : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _hingeRenderer;
        [SerializeField] private MeshRenderer _handleRenderer;
        [SerializeField] private MeshRenderer _headRenderer;

        private MeshFilter _stickFilter;
        private MeshFilter _headFilter;

        private void Awake()
        {
            _stickFilter = _handleRenderer.gameObject.GetComponent<MeshFilter>();
            _headFilter = _headRenderer.gameObject.GetComponent<MeshFilter>();
        }

        public void ChangeSkin(HammerSkinProduct skin)
        {
            _hingeRenderer.sharedMaterial = skin.HammerHingeMaterial;
            _handleRenderer.sharedMaterial = skin.HammerStickMaterial;
            _headRenderer.sharedMaterial = skin.HammerHeadMaterial;
            _stickFilter.sharedMesh = skin.HammerStick;
            _headFilter.sharedMesh = skin.HammerHead;
        }
    }
}