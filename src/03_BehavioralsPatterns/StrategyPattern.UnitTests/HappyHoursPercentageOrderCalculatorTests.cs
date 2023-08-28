using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StrategyPattern.UnitTests
{
    [TestClass]
    public class HappyHoursCanDiscountStrategyTests
    {
        private ICanDiscountStrategy strategy;
        private Order order;

        private readonly TimeSpan from = TimeSpan.Parse("09:00");
        private readonly TimeSpan to = TimeSpan.Parse("15:00");

        [TestInitialize]
        public void Init()
        {
            order = new Order(DateTime.MinValue, new Customer(), 100);

            strategy = new HappyHoursCanDiscountStrategy(from, to);
        }

        [TestMethod]
        public void CalculateDiscount_DuringHappyHours_ShouldDiscount()
        {
            // Arrange
            order.OrderDate = DateTime.Parse("2020-06-12 14:59");

            // Act
            var result = strategy.CanDiscount(order);

            // Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CalculateDiscount_BeforeHappyHours_ShouldNotDiscount()
        {
            // Arrange
            order.OrderDate = DateTime.Parse("2020-06-12 08:59");

            // Act
            var result = strategy.CanDiscount(order);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalculateDiscount_AfterHappyHours_ShouldNotDiscount()
        {
            // Arrange
            order.OrderDate = DateTime.Parse("2020-06-12 15:01");

            // Act
            var result = strategy.CanDiscount(order);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
