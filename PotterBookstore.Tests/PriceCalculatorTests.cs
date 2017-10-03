using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore.Tests
{
    [TestFixture]
    public class PriceCalculatorTests
    {
        private PriceCalculator underTest;

        private IDiscountHelper discountHelper;

        private IBasket basket;

        [SetUp]
        public void SetUp()
        {
            basket = new Basket();
            discountHelper = new PotterDiscountHelper();
        }

        [Test]
        public void WhenNoBooksInBasket_CostShouldBe0()
        {
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(0, totalPrice);
        }

        [Test]
        public void WhenOneBookInBasket_CostShouldBe8Dollars()
        {
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(8, totalPrice);
        }

        [Test]
        public void WhenTwoSameBooksInBasket_CostShouldBe16Dollars()
        {
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(16, totalPrice);
        }

        [Test]
        public void WhenTwoDifferentBooksInBasket_CostShouldBeWith5PercentsDiscount()
        {
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            basket.AddProduct(PotterBookProductGenerator.bookList[1]);
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(15.2, totalPrice);
        }

        [Test]
        public void WhenTwoCopiesOfTwoDifferentBooksInBasket_OnlyTwoOfThemGet5PercentDiscount()
        {
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            basket.AddProduct(PotterBookProductGenerator.bookList[1]);
            basket.AddProduct(PotterBookProductGenerator.bookList[1]);
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(31.2, totalPrice);
        }

        [Test]
        public void WhenThreeDifferentBooksInBasket_CostShouldBeWith10PercentsDiscount()
        {
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            basket.AddProduct(PotterBookProductGenerator.bookList[1]);
            basket.AddProduct(PotterBookProductGenerator.bookList[2]);
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(21.6, totalPrice);
        }

        [Test]
        public void WhenFourDifferentBooksInBasket_CostShouldBeWith15PercentsDiscount()
        {
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            basket.AddProduct(PotterBookProductGenerator.bookList[1]);
            basket.AddProduct(PotterBookProductGenerator.bookList[2]);
            basket.AddProduct(PotterBookProductGenerator.bookList[3]);
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(27.2, totalPrice);
        }

        [Test]
        public void WhenFiveDifferentBooksInBasket_CostShouldBeWith25PercentsDiscount()
        {
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            basket.AddProduct(PotterBookProductGenerator.bookList[1]);
            basket.AddProduct(PotterBookProductGenerator.bookList[2]);
            basket.AddProduct(PotterBookProductGenerator.bookList[3]);
            basket.AddProduct(PotterBookProductGenerator.bookList[4]);
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(30, totalPrice);
        }

        [Test]
        public void WhenSixDifferentBooksInBasket_CostShouldBeWith30PercentsDiscount()
        {
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            basket.AddProduct(PotterBookProductGenerator.bookList[1]);
            basket.AddProduct(PotterBookProductGenerator.bookList[2]);
            basket.AddProduct(PotterBookProductGenerator.bookList[3]);
            basket.AddProduct(PotterBookProductGenerator.bookList[4]);
            basket.AddProduct(PotterBookProductGenerator.bookList[5]);
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(33.6, totalPrice);
        }

        [Test]
        public void WhenSevenDifferentBooksInBasket_CostShouldBeWith35PercentsDiscount()
        {
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            basket.AddProduct(PotterBookProductGenerator.bookList[1]);
            basket.AddProduct(PotterBookProductGenerator.bookList[2]);
            basket.AddProduct(PotterBookProductGenerator.bookList[3]);
            basket.AddProduct(PotterBookProductGenerator.bookList[4]);
            basket.AddProduct(PotterBookProductGenerator.bookList[5]);
            basket.AddProduct(PotterBookProductGenerator.bookList[6]);
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(36.4, totalPrice);
        }

        [Test]
        public void WhenSixDifferentBooksWithSomeRepeatsInBasket_OnlyCostOfFirstCopiesOfBooksShouldBeWith30PercentsDiscount()
        {
            basket.AddProduct(PotterBookProductGenerator.bookList[0]);
            basket.AddProduct(PotterBookProductGenerator.bookList[1], 2);
            basket.AddProduct(PotterBookProductGenerator.bookList[2], 2);
            basket.AddProduct(PotterBookProductGenerator.bookList[3], 2);
            basket.AddProduct(PotterBookProductGenerator.bookList[4], 2);
            basket.AddProduct(PotterBookProductGenerator.bookList[5]);
            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            Assert.AreEqual(65.6, totalPrice);
        }

        [Test]
        [TestCase(new int[] { 0, 1, 2, 3, 6 }, ExpectedResult = 70)]
        [TestCase(new int[] { 0, 1, 3, 4 }, ExpectedResult = 59.2)]
        public decimal WhenDifferentBooksWithSomeRepeatsInBasket_OnlyCostOfFirstCopiesOfBooksShouldBeWithDiscount(
            int[] bookNumbers)
        {
            foreach (int number in bookNumbers)
            {
                basket.AddProduct(PotterBookProductGenerator.bookList[number], 2);
            }

            underTest = new PriceCalculator(basket, discountHelper);

            decimal totalPrice = underTest.GetTotalPrice();

            return totalPrice;
        }
    }
}

