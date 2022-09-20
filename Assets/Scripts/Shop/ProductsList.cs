using System;
using System.Collections.Generic;
using Money;
using UnityEngine;

namespace Shop
{
    public class ProductsList : MonoBehaviour
    {
        [SerializeField] private Product[] _products;
        [SerializeField] private ProductHandler _productTemplate;
        [SerializeField] private Transform _productsContainer;

        [SerializeField] private List<ProductHandler> _handlers = new List<ProductHandler>();
        
        public static event Action<Product> ProductActivated;

        private void Awake()
        {
            CreateProducts();
        }

        private void CreateProducts()
        {
            foreach (var product in _products)
            {
                var newProduct = Instantiate(_productTemplate, _productsContainer);
                newProduct.Init(product);
                _handlers.Add(newProduct);
            }
        }

        private void OnEnable()
        {
            foreach (var handler in _handlers)
                handler.ProductClicked += ClickProduct;
        }

        private void OnDisable()
        {
            foreach (var handler in _handlers)
                handler.ProductClicked -= ClickProduct;
        }

        private void ClickProduct(Product product)
        {
            if (product.IsBought)
            {
                ProductActivated?.Invoke(product);
            }
            else if (Wallet.GetMoneyCount() >= product.Price)
            {
                product.Buy();
                ProductActivated?.Invoke(product);
            }
            //else
                //Play buy failed sound
        }
    }
}