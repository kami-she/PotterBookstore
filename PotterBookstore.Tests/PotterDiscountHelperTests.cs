using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore.Tests
{
    [TestFixture]
    public class PotterDiscountHelperTests
    {
        private PotterDiscountHelper underTest;

        [SetUp]
        public void SetUp()
        {
            underTest = new PotterDiscountHelper();
        }

        [Test]
        public void WhenProductCountIsInDiscountHelper_ShouldReturnCorrectDiscount()
        {
            decimal result = underTest.GetDiscount(2);

            Assert.AreEqual(0.05, result);
        }

        [Test]
        public void WhenProductCountIsNotInDiscountHelper_ShouldThrowException()
        {
            decimal result = underTest.GetDiscount(2);

            Assert.Throws<InvalidOperationException>(() => underTest.GetDiscount(10));
        }
    }
}
