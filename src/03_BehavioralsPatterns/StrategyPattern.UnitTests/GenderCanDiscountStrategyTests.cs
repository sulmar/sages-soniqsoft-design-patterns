using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StrategyPattern.UnitTests
{
    [TestClass]
    public class GenderCanDiscountStrategyTests
    {
        private ICanDiscountStrategy strategy;

        private Order order;

        [TestInitialize]
        public void Init()
        {
            order = new Order(DateTime.MinValue, new Customer(), 100);

            strategy = new GenderCanDiscountStrategy(Gender.Female);
        }

        [TestMethod]
        public void CalculateDiscount_Female_ShouldDiscount()
        {
            // Arrange
            order.Customer.Gender = Gender.Female;            

            // Act
            var result = strategy.CanDiscount(order);

            // Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CalculateDiscount_Male_ShouldNotDiscount()
        {
            // Arrange
            order.Customer.Gender = Gender.Male;

            // Act
            var result = strategy.CanDiscount(order);

            // Assert
            Assert.IsFalse(result);

        }

    }
}
