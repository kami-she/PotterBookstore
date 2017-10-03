using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore
{
    public interface IBasket
    {
        Dictionary<IProduct, int> GetBasketProducts { get; }

        void AddProduct(IProduct product, int amount = 1);
    }
}
