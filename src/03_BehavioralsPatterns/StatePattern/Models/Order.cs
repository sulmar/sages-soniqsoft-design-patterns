using Stateless;
using System;
using System.Diagnostics.Tracing;

namespace StatePattern
{
    // dotnet add package Stateless
    // https://github.com/dotnet-state-machine/stateless

    public class Order
    {
        private readonly StateMachine<OrderStatus, OrderTrigger> machine;

        public Order(OrderStatus initialState = OrderStatus.Placement)
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.Now;

            machine = new StateMachine<OrderStatus, OrderTrigger>(initialState);

            machine.Configure(OrderStatus.Placement)
                .PermitIf(OrderTrigger.Confirm, OrderStatus.Picking, () => IsPaid, "Zapłacono")
                .IgnoreIf(OrderTrigger.Confirm, () => !IsPaid, "Nie zapłacono")
                .Permit(OrderTrigger.Cancel, OrderStatus.Canceled);

            machine.Configure(OrderStatus.Picking)
                .Permit(OrderTrigger.Confirm, OrderStatus.Shipping);

            machine.Configure(OrderStatus.Shipping)
                .OnEntry(() => Console.WriteLine($"Your order {Id} is ready to send."), "Send email")
                .Permit(OrderTrigger.Confirm, OrderStatus.Delivered)
                .OnExit(() => Console.WriteLine($"Your order {Id} was sent."), "Send email");

            machine.Configure(OrderStatus.Delivered)
                .Permit(OrderTrigger.Confirm, OrderStatus.Completed)
                .Permit(OrderTrigger.Cancel, OrderStatus.Canceled);

            machine.Configure(OrderStatus.Completed);

            machine.OnTransitioned(transition =>
            {
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{transition.Source} -> {transition.Destination}");
                System.Console.ResetColor();

            });
        }

        // http://www.webgraphviz.com
        public string Graph => Stateless.Graph.UmlDotGraph.Format(machine.GetInfo());

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status => machine.State;
        public bool IsPaid { get; private set; }

        public void Paid()
        {
            IsPaid = true;
        }

        public void Confirm() => machine.Fire(OrderTrigger.Confirm);
        public void Cancel() => machine.Fire(OrderTrigger.Cancel);

        public override string ToString() => $"Order {Id} created on {OrderDate}{Environment.NewLine}";

        public virtual bool CanConfirm => machine.CanFire(OrderTrigger.Confirm);
        public virtual bool CanCancel => machine.CanFire(OrderTrigger.Cancel);
    }

    public enum OrderStatus
    {
        // The customer places an order on the company's website
        Placement,
        // The items from the order are picked from the inventory
        Picking,
        // The package is handed over to the shipping carrier or courier for delivery to the customer.      
        Shipping,
        // The package has been successfully delivered to the customer's specified address.
        Delivered,
        // The order has been successfully delivered, and the transaction is considered complete.
        Completed,
        // The customer canceled order
        Canceled

    }

    public enum OrderTrigger
    {
        Confirm,
        Cancel
    }

}
