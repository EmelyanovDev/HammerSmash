using Hammer;
using Shop;
using UnityEngine;

namespace Skins
{
    public class SkinsHandler : MonoBehaviour
    {
        [SerializeField] private HammerSkin _hammerSkin;

        private const string SkinKey = "SkinKey";
        
        private void OnEnable()
        {
            ProductsList.ProductActivated += SetSkin;
        }

        private void OnDisable()
        {
            ProductsList.ProductActivated -= SetSkin;
        }

        private void SetSkin(Product product)
        {
            PlayerPrefs.SetString(SkinKey, product.name);
            switch (product.ProductType)
            {
                case ProductType.HammerSkin:
                    _hammerSkin.ChangeSkin(product as HammerSkinProduct);
                    break;
            }
        }
    }
}