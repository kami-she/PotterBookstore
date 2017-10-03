using System.Collections.Generic;
using PotterBookstore.Models;

namespace PotterBookstore
{
    public class Basket : IBasket
    {
        private readonly Dictionary<IProduct, int> _products = new Dictionary<IProduct, int>();

        public Dictionary<IProduct, int> GetBasketProducts => _products;

        public void AddProduct(IProduct product, int amount = 1)
        {
            if (_products.ContainsKey(product))
            {
                _products[product] += amount;
            }
            else
            {
                _products.Add(product, amount);
            }
        }
    }
}
