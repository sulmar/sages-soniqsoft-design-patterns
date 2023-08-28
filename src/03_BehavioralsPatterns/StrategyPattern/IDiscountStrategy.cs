namespace StrategyPattern
{
    // Abstract strategy
    public interface IDiscountStrategy
    {
        decimal Discount(Order order);
        decimal NoDiscount();
    }
}
