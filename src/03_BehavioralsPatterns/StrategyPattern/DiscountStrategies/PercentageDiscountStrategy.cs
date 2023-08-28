namespace StrategyPattern
{
    // Concrete strategy
    public class PercentageDiscountStrategy : BaseDiscountStrategy, IDiscountStrategy
    {
        private readonly decimal percentage;

        public PercentageDiscountStrategy(decimal percentage) => this.percentage = percentage;

        public override decimal Discount(Order order) => order.Amount * percentage;
    }


    
}
