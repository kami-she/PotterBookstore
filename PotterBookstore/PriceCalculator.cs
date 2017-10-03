using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly Dictionary<IProduct, int> products;

        private readonly IDiscountHelper discountHelper;

        public PriceCalculator(Dictionary<IProduct, int> products)
        {
            this.products = products;
            discountHelper = new PotterDiscountHelper();
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            int uniqueProductsCount = products.Count;

            decimal discountSize = discountHelper.GetDiscount(uniqueProductsCount);

            foreach (var key in products.Keys)
            {
                totalPrice += key.Price * (1 - discountSize);
            }

            return totalPrice;
        }
    }
}
