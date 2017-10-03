namespace PotterBookstore
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly IBasket _basket;

        private readonly IDiscountHelper _discountHelper;

        public PriceCalculator(IBasket basket, IDiscountHelper discountHelper)
        {
            _basket = basket;
            _discountHelper = discountHelper;
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;

            var basketProducts = _basket.GetBasketProducts;
            var uniqueProductsCount = basketProducts.Count;

            var discountSize = _discountHelper.GetDiscount(uniqueProductsCount);

            foreach (var key in basketProducts.Keys)
            {
                totalPrice += key.Price * (basketProducts[key] - discountSize);
            }

            return totalPrice;
        }
    }
}
