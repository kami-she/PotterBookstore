using System.Collections.Generic;
using PotterBookstore.Models;

namespace PotterBookstore
{
    public interface IBasket
    {
        Dictionary<IProduct, int> GetBasketProducts { get; }

        void AddProduct(IProduct product, int amount = 1);
    }
}
