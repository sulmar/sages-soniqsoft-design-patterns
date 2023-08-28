using System;

namespace TemplateMethodPattern
{
    public class SpecialDayPercentageOrderCalculator : OrderCalculator
    {
        private readonly DateTime specialDay;

        private readonly decimal percentage;

        public SpecialDayPercentageOrderCalculator(DateTime specialDay, decimal percentage)
        {
            this.specialDay = specialDay;
            this.percentage = percentage;
        }

        protected override bool CanDiscount(Order order) => order.OrderDate == specialDay;
        protected override decimal GetDiscount(Order order) => order.Amount * percentage;
    }



}
