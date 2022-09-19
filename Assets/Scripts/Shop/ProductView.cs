using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ProductView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _priceText;

        public void Init(Product product)
        {
            _icon.sprite = product.Icon;
            _priceText.text = product.Price.ToString();
            if(product.IsBought)
                _priceText.gameObject.SetActive(false);
        }

        public void DeactivatePriceText()
        {
            _priceText.gameObject.SetActive(false);
        }
    }
}