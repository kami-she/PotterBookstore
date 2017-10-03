using NUnit.Framework;

namespace PotterBookstore.Tests
{
    [TestFixture]
    public class BasketTests
    {
        private Basket underTest;

        [SetUp]
        public void SetUp()
        {
            underTest = new Basket();
        }

        [Test]
        public void WhenAddProductToBasket_ShouldReturnCorrectProductsCount()
        {
            Assert.AreEqual(0, underTest.GetBasketProducts.Count);

            underTest.AddProduct(PotterBookProductGenerator.bookList[0]);

            Assert.AreEqual(1, underTest.GetBasketProducts.Count);
        }
    }
}
