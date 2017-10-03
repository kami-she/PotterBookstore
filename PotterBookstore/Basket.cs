using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore
{
    public class Basket : IBasket
    {
        private readonly Dictionary<IProduct, int> products = new Dictionary<IProduct, int>();

        public Dictionary<IProduct, int> GetBasketProducts
        {
            get { return products; }
        }

        public void AddProduct(IProduct product, int amount = 1)
        {
            if (products.ContainsKey(product))
            {
                products[product] += amount;
            }
            else
            {
                products.Add(product, amount);
            }
        }
    }
}
