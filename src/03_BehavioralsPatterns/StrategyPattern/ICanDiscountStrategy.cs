namespace StrategyPattern
{
    // Abstract strategy
    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);
    }
}
