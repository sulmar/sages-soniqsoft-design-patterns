using System;

namespace StrategyPattern
{
    // Concrete strategy
    public class FixedDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal amount;

        public FixedDiscountStrategy(decimal amount) => this.amount = amount;
        public decimal Discount(Order order) => amount;

        public decimal NoDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
