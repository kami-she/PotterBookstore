using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly IBasket basket;

        private readonly IDiscountHelper discountHelper;

        public PriceCalculator(IBasket basket, IDiscountHelper discountHelper)
        {
            this.basket = basket;
            this.discountHelper = discountHelper;
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;

            Dictionary<IProduct, int> basketProducts = basket.GetBasketProducts;
            int uniqueProductsCount = basketProducts.Count;

            decimal discountSize = discountHelper.GetDiscount(uniqueProductsCount);

            foreach (var key in basketProducts.Keys)
            {
                totalPrice += key.Price * (basketProducts[key] - discountSize);
            }

            return totalPrice;
        }
    }
}
