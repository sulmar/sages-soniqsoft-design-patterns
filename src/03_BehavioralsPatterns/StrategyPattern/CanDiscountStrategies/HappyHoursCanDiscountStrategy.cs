﻿using System;

namespace StrategyPattern
{
    // Concrete strategy
    public class HappyHoursCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public HappyHoursCanDiscountStrategy(TimeSpan from, TimeSpan to)
        {
            this.from = from;
            this.to = to;
        }

        public bool CanDiscount(Order order) => order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay <= to;
    }
}
