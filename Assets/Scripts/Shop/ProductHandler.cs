using System;
using UnityEngine;

namespace Shop
{
    [RequireComponent(typeof(ProductView))]
    [RequireComponent(typeof(ProductButton))]
    
    public class ProductHandler : MonoBehaviour
    {
        private ProductView _view;
        private ProductButton _button;

        private Product _selfProduct;

        public event Action<Product> ProductClicked;

        private void Awake()
        {
            _view = GetComponent<ProductView>();
            _button = GetComponent<ProductButton>();
        }

        private void OnEnable()
        {
            _selfProduct.ProductBought += _view.DeactivatePriceText;
        }
        
        private void OnDisable()
        {
            _selfProduct.ProductBought -= _view.DeactivatePriceText;
        }

        public void Init(Product product)
        {
            _view.Init(product);
            _button.Init(this);
            _selfProduct = product;
        }

        public void Click()
        {
            ProductClicked?.Invoke(_selfProduct);
        }
    }
}