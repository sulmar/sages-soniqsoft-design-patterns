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

        public decimal CalculateDiscount(Order order)   // Template Method
        {
            if (CanDiscount(order)) // Predicate Warunek promocji
            {
                return GetDiscount(order);
            }
            else
                return GetNoDiscount();
        }
    }



}
