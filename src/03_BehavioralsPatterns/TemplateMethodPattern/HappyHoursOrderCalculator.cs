using System;

namespace TemplateMethodPattern
{
    public abstract class OrderCalculator
    {
        protected abstract bool CanDiscount(Order order);
        protected abstract decimal GetDiscount(Order order);
        protected virtual decimal GetNoDiscount()
        {
            return 0;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (CanDiscount(order)) // Predicate Warunek promocji
            {
                return GetDiscount(order);
            }
            else
                return GetNoDiscount();
        }
    }
        


    // Happy Hours - 10% upustu w godzinach od 8:30 do 15
    public class HappyHoursPercentageOrderCalculator : OrderCalculator
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;   

        private readonly decimal percentage;

        public HappyHoursPercentageOrderCalculator(TimeSpan from, TimeSpan to, decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;            
        }

        protected override bool CanDiscount(Order order) => order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay < to;
        protected override decimal GetDiscount(Order order) => order.Amount * percentage;
    }


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
