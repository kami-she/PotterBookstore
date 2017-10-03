using NUnit.Framework;

namespace PotterBookstore.Tests
{
    [TestFixture]
    public class PriceCalculatorTests
    {
        private PriceCalculator _underTest;

        private IDiscountHelper _discountHelper;

        private IBasket _basket;

        [SetUp]
        public void SetUp()
        {
            _basket = new Basket();
            _discountHelper = new PotterDiscountHelper();
        }

        [Test]
        public void WhenNoBooksInBasket_CostShouldBe0()
        {
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(0, totalPrice);
        }

        [Test]
        public void WhenOneBookInBasket_CostShouldBe8Dollars()
        {
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(8, totalPrice);
        }

        [Test]
        public void WhenTwoSameBooksInBasket_CostShouldBe16Dollars()
        {
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(16, totalPrice);
        }

        [Test]
        public void WhenTwoDifferentBooksInBasket_CostShouldBeWith5PercentsDiscount()
        {
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[1]);
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(15.2, totalPrice);
        }

        [Test]
        public void WhenTwoCopiesOfTwoDifferentBooksInBasket_OnlyTwoOfThemGet5PercentDiscount()
        {
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[1]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[1]);
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(31.2, totalPrice);
        }

        [Test]
        public void WhenThreeDifferentBooksInBasket_CostShouldBeWith10PercentsDiscount()
        {
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[1]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[2]);
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(21.6, totalPrice);
        }

        [Test]
        public void WhenFourDifferentBooksInBasket_CostShouldBeWith15PercentsDiscount()
        {
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[1]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[2]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[3]);
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(27.2, totalPrice);
        }

        [Test]
        public void WhenFiveDifferentBooksInBasket_CostShouldBeWith25PercentsDiscount()
        {
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[1]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[2]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[3]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[4]);
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(30, totalPrice);
        }

        [Test]
        public void WhenSixDifferentBooksInBasket_CostShouldBeWith30PercentsDiscount()
        {
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[1]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[2]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[3]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[4]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[5]);
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(33.6, totalPrice);
        }

        [Test]
        public void WhenSevenDifferentBooksInBasket_CostShouldBeWith35PercentsDiscount()
        {
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[1]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[2]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[3]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[4]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[5]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[6]);
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(36.4, totalPrice);
        }

        [Test]
        public void WhenSixDifferentBooksWithSomeRepeatsInBasket_OnlyCostOfFirstCopiesOfBooksShouldBeWith30PercentsDiscount()
        {
            _basket.AddProduct(PotterBookProductGenerator.BookList[0]);
            _basket.AddProduct(PotterBookProductGenerator.BookList[1], 2);
            _basket.AddProduct(PotterBookProductGenerator.BookList[2], 2);
            _basket.AddProduct(PotterBookProductGenerator.BookList[3], 2);
            _basket.AddProduct(PotterBookProductGenerator.BookList[4], 2);
            _basket.AddProduct(PotterBookProductGenerator.BookList[5]);
            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            Assert.AreEqual(65.6, totalPrice);
        }

        [TestCase(new[] { 0, 1, 2, 3, 6 }, ExpectedResult = 70)]
        [TestCase(new[] { 0, 1, 3, 4 }, ExpectedResult = 59.2)]
        public decimal WhenDifferentBooksWithSomeRepeatsInBasket_OnlyCostOfFirstCopiesOfBooksShouldBeWithDiscount(
            int[] bookNumbers)
        {
            foreach (var number in bookNumbers)
            {
                _basket.AddProduct(PotterBookProductGenerator.BookList[number], 2);
            }

            _underTest = new PriceCalculator(_basket, _discountHelper);

            decimal totalPrice = _underTest.GetTotalPrice();

            return totalPrice;
        }
    }
}

