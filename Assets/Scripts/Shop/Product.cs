using System;
using Money;
using UnityEngine;

namespace Shop
{
    public class Product : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _price;
        [SerializeField] private ProductType _productType;

        public Sprite Icon => _icon;
        public int Price => _price;
        public ProductType ProductType => _productType;
        public bool IsBought => PlayerPrefs.HasKey(name);

        public event Action ProductBought;

        public void Buy()
        {
            Wallet.ChangeMoneyCount(-_price);
            PlayerPrefs.SetInt(name, 1);
            ProductBought?.Invoke();
        }
    }
}