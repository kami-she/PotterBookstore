using System;
using NUnit.Framework;

namespace PotterBookstore.Tests
{
    [TestFixture]
    public class PotterDiscountHelperTests
    {
        private PotterDiscountHelper _underTest;

        [SetUp]
        public void SetUp()
        {
            _underTest = new PotterDiscountHelper();
        }

        [Test]
        public void WhenProductCountIsInDiscountHelper_ShouldReturnCorrectDiscount()
        {
            decimal result = _underTest.GetDiscount(2);

            Assert.AreEqual(0.05, result);
        }

        [Test]
        public void WhenProductCountIsNotInDiscountHelper_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _underTest.GetDiscount(10));
        }
    }
}
