using NUnit.Framework;

namespace PotterBookstore.Tests
{
    [TestFixture]
    public class BasketTests
    {
        private Basket _underTest;

        [SetUp]
        public void SetUp()
        {
            _underTest = new Basket();
        }

        [Test]
        public void WhenAddProductToBasket_ShouldReturnCorrectProductsCount()
        {
            Assert.AreEqual(0, _underTest.GetBasketProducts.Count);

            _underTest.AddProduct(PotterBookProductGenerator.BookList[0]);

            Assert.AreEqual(1, _underTest.GetBasketProducts.Count);
        }
    }
}
