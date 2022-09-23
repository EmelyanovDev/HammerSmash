using Hammer;
using Shop;
using UnityEngine;

namespace Skins
{
    public class SkinsHandler : MonoBehaviour
    {
        [SerializeField] private HammerSkin _hammerSkin;

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
            switch (product.ProductType)
            {
                case ProductType.HammerSkin:
                    _hammerSkin.ChangeSkin(product as HammerSkinProduct);
                    break;
            }
        }
    }
}