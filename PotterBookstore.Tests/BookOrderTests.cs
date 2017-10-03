using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            double totalPrice = order.getTotalPrice();
            Assert.AreEqual(0, totalPrice);
        }

        [Test]
        public void WhenOneBookInBasket_CostShouldBe8Dollars()
        {
            order.AddBook(Book.FirstBook);
            double totalPrice = order.getTotalPrice();
            Assert.AreEqual(8, totalPrice);
        }

        [Test]
        public void WhenTwoSameBooksInBasket_CostShouldBe16Dollars()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.FirstBook);
            double totalPrice = order.getTotalPrice();
            Assert.AreEqual(16, totalPrice);
        }

        [Test]
        public void WhenTwoDifferentBooksInBasket_CostShouldBeWith5PercentsDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            double totalPrice = order.getTotalPrice();
            Assert.AreEqual(15.2, totalPrice);
        }

        [Test]
        public void WhenTwoCopiesOfTwoDifferentBooksInBasket_OnlyTwoOfThemGet5PercentDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            order.AddBook(Book.SecondBook);
            double totalPrice = order.getTotalPrice();
            Assert.AreEqual(31.2, totalPrice);
        }

        [Test]
        public void WhenThreeDifferentBooksInBasket_CostShouldBeWith10PercentsDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            order.AddBook(Book.ThirdBook);
            double totalPrice = order.getTotalPrice();
            Assert.AreEqual(21.6, totalPrice);
        }

        [Test]
        public void WhenFourDifferentBooksInBasket_CostShouldBeWith20PercentsDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            order.AddBook(Book.ThirdBook);
            order.AddBook(Book.SixthBook);
            double totalPrice = order.getTotalPrice();
            Assert.AreEqual(27.2, totalPrice);
        }
    }
}
