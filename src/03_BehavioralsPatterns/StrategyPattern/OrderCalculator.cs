namespace StrategyPattern
{
    public class OrderCalculator
    {
        private readonly ICanDiscountStrategy canDiscountStrategy;
        private readonly IDiscountStrategy _discountStrategy;

        public OrderCalculator(
            ICanDiscountStrategy canDiscountStrategy,
            IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
            this.canDiscountStrategy = canDiscountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (canDiscountStrategy.CanDiscount(order))   // Predykat (CanDiscount)
            {
                return _discountStrategy.Discount(order); // Upust (Discount)
            }
            else
                return _discountStrategy.NoDiscount(); // brak upustu (NoDiscount)
        }
    }
}
