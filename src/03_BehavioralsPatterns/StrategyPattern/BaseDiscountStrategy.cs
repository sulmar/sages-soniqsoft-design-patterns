namespace StrategyPattern
{
    public abstract class BaseDiscountStrategy : IDiscountStrategy
    {
        public abstract decimal Discount(Order order);
        public virtual decimal NoDiscount() => decimal.Zero;

    }
}
