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
            int totalPrice = order.getTotalPrice();
            Assert.AreEqual(0, totalPrice);
        }

        [Test]
        public void WhenOneBookInBasket_CostShouldBe8Dollars()
        {
            order.AddBook(Book.FirstBook);
            int totalPrice = order.getTotalPrice();
            Assert.AreEqual(8, totalPrice);
        }

        [Test]
        public void WhenTwoSameBooksInBasket_CostShouldBe16Dollars()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.FirstBook);
            int totalPrice = order.getTotalPrice();
            Assert.AreEqual(16, totalPrice);
        }


    }
}
