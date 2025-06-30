using System.Collections.Generic;
using System.Globalization;
using SupermarketReceipt.interfaces;

namespace SupermarketReceipt
{
    public class ShoppingCart: ICart
    {
        private readonly List<ProductQuantity> _items = [];
        private readonly Dictionary<Product, double> _productQuantities = new();


        public List<ProductQuantity> GetItems()
        {
            return new List<ProductQuantity>(_items);
        }

        public void AddItem(Product product)
        {
            AddItemQuantity(product, 1);
        }


        public void AddItemQuantity(Product product, double quantity)
        {
            _items.Add(new ProductQuantity(product, quantity));
            if (_productQuantities.TryAdd(product, quantity))
            {
                return;
            }
            
            _productQuantities[product] = _productQuantities[product] + quantity;
        }

        public double? GetItemQuantity(Product product)
        {
            if (_productQuantities.TryGetValue(product, out var quantity)) {
                return quantity;
            }

            return null;
        }
        
    }
}