using NUnit.Framework;
using System.Collections.Generic;

namespace PotterBookstore.Tests
{
    [TestFixture]
    public class BookOrderTests
    {
        private BookOrder order;

        [SetUp]
        public void SetUp()
        {
            order = new BookOrder();
        }

        [Test]
        public void WhenNoBooksInBasket_CostShouldBe0()
        {
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(0, totalPrice);
        }

        [Test]
        public void WhenOneBookInBasket_CostShouldBe8Dollars()
        {
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(8, totalPrice);
        }

        [Test]
        public void WhenTwoSameBooksInBasket_CostShouldBe16Dollars()
        {
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(16, totalPrice);
        }

        [Test]
        public void WhenTwoDifferentBooksInBasket_CostShouldBeWith5PercentsDiscount()
        {
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            order.AddBook(PotterBookProductGenerator.bookList[1]);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(15.2, totalPrice);
        }

        [Test]
        public void WhenTwoCopiesOfTwoDifferentBooksInBasket_OnlyTwoOfThemGet5PercentDiscount()
        {
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            order.AddBook(PotterBookProductGenerator.bookList[1]);
            order.AddBook(PotterBookProductGenerator.bookList[1]);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(31.2, totalPrice);
        }

        [Test]
        public void WhenThreeDifferentBooksInBasket_CostShouldBeWith10PercentsDiscount()
        {
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            order.AddBook(PotterBookProductGenerator.bookList[1]);
            order.AddBook(PotterBookProductGenerator.bookList[2]);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(21.6, totalPrice);
        }

        [Test]
        public void WhenFourDifferentBooksInBasket_CostShouldBeWith15PercentsDiscount()
        {
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            order.AddBook(PotterBookProductGenerator.bookList[1]);
            order.AddBook(PotterBookProductGenerator.bookList[2]);
            order.AddBook(PotterBookProductGenerator.bookList[3]);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(27.2, totalPrice);
        }

        [Test]
        public void WhenFiveDifferentBooksInBasket_CostShouldBeWith25PercentsDiscount()
        {
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            order.AddBook(PotterBookProductGenerator.bookList[1]);
            order.AddBook(PotterBookProductGenerator.bookList[2]);
            order.AddBook(PotterBookProductGenerator.bookList[3]);
            order.AddBook(PotterBookProductGenerator.bookList[4]);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(30, totalPrice);
        }

        [Test]
        public void WhenSixDifferentBooksInBasket_CostShouldBeWith30PercentsDiscount()
        {
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            order.AddBook(PotterBookProductGenerator.bookList[1]);
            order.AddBook(PotterBookProductGenerator.bookList[2]);
            order.AddBook(PotterBookProductGenerator.bookList[3]);
            order.AddBook(PotterBookProductGenerator.bookList[4]);
            order.AddBook(PotterBookProductGenerator.bookList[5]);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(33.6, totalPrice);
        }

        [Test]
        public void WhenSevenDifferentBooksInBasket_CostShouldBeWith35PercentsDiscount()
        {
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            order.AddBook(PotterBookProductGenerator.bookList[1]);
            order.AddBook(PotterBookProductGenerator.bookList[2]);
            order.AddBook(PotterBookProductGenerator.bookList[3]);
            order.AddBook(PotterBookProductGenerator.bookList[4]);
            order.AddBook(PotterBookProductGenerator.bookList[5]);
            order.AddBook(PotterBookProductGenerator.bookList[6]);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(36.4, totalPrice);
        }

        [Test]
        public void WhenSixDifferentBooksWithSomeRepeatsInBasket_OnlyCostOfFirstCopiesOfBooksShouldBeWith30PercentsDiscount()
        {
            order.AddBook(PotterBookProductGenerator.bookList[0]);
            order.AddBook(PotterBookProductGenerator.bookList[1], 2);
            order.AddBook(PotterBookProductGenerator.bookList[2], 2);
            order.AddBook(PotterBookProductGenerator.bookList[3], 2);
            order.AddBook(PotterBookProductGenerator.bookList[4], 2);
            order.AddBook(PotterBookProductGenerator.bookList[5]);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(65.6, totalPrice);
        }
    }
}
