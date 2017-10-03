using NUnit.Framework;

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
            order.AddBook(Book.FirstBook);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(8, totalPrice);
        }

        [Test]
        public void WhenTwoSameBooksInBasket_CostShouldBe16Dollars()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.FirstBook);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(16, totalPrice);
        }

        [Test]
        public void WhenTwoDifferentBooksInBasket_CostShouldBeWith5PercentsDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(15.2, totalPrice);
        }

        [Test]
        public void WhenTwoCopiesOfTwoDifferentBooksInBasket_OnlyTwoOfThemGet5PercentDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            order.AddBook(Book.SecondBook);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(31.2, totalPrice);
        }

        [Test]
        public void WhenThreeDifferentBooksInBasket_CostShouldBeWith10PercentsDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            order.AddBook(Book.ThirdBook);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(21.6, totalPrice);
        }

        [Test]
        public void WhenFourDifferentBooksInBasket_CostShouldBeWith15PercentsDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            order.AddBook(Book.ThirdBook);
            order.AddBook(Book.SixthBook);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(27.2, totalPrice);
        }

        [Test]
        public void WhenFiveDifferentBooksInBasket_CostShouldBeWith25PercentsDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            order.AddBook(Book.ThirdBook);
            order.AddBook(Book.FifthBook);
            order.AddBook(Book.SixthBook);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(30, totalPrice);
        }

        [Test]
        public void WhenSixDifferentBooksInBasket_CostShouldBeWith30PercentsDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            order.AddBook(Book.ThirdBook);
            order.AddBook(Book.FourthBook);
            order.AddBook(Book.FifthBook);
            order.AddBook(Book.SixthBook);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(33.6, totalPrice);
        }

        [Test]
        public void WhenSevenDifferentBooksInBasket_CostShouldBeWith35PercentsDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook);
            order.AddBook(Book.ThirdBook);
            order.AddBook(Book.FourthBook);
            order.AddBook(Book.FifthBook);
            order.AddBook(Book.SixthBook);
            order.AddBook(Book.SeventhBook);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(36.4, totalPrice);
        }

        [Test]
        public void WhenSixDifferentBooksWithSomeRepeatsInBasket_OnlyCostOfFirstCopiesOfBooksShouldBeWith30PercentsDiscount()
        {
            order.AddBook(Book.FirstBook);
            order.AddBook(Book.SecondBook, 2);
            order.AddBook(Book.ThirdBook, 2);
            order.AddBook(Book.FourthBook, 2);
            order.AddBook(Book.FifthBook, 2);
            order.AddBook(Book.SixthBook);
            decimal totalPrice = order.getTotalPrice();
            Assert.AreEqual(65.6, totalPrice);
        }
    }
}
