using System;

namespace DecoratorPattern
{

    // Abstract Component
    public abstract class Employee
    {
        public TimeSpan OvertimeSalary { get; set; }
        public int NumberOfProjects { get; set; }
        public abstract decimal GetSalary();
    }

    // Abstract Decorator
    public abstract class EmployeeDecorator : Employee
    {
        // Decorated Component
        protected Employee employee;

        protected EmployeeDecorator(Employee employee)
        {
            this.employee = employee;
        }

        public override decimal GetSalary()
        {
            if (employee != null)
            {
                return this.employee.GetSalary();
            }
            return decimal.Zero;
        }
    }

    public class OverTimeEmployeeDecorator : EmployeeDecorator
    {
        private readonly decimal amountPerHour;
        public OverTimeEmployeeDecorator(Employee employee, decimal amountPerHour) : base(employee)
        {
            this.amountPerHour = amountPerHour;
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + (decimal) employee.OvertimeSalary.TotalHours * amountPerHour; ;
        }
    }


    public class ProjectEmployeeDecorator : EmployeeDecorator
    {
        private readonly decimal bonusPerProject;

        public ProjectEmployeeDecorator(Employee employee) : base(employee)
        {
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + employee.NumberOfProjects * bonusPerProject;
        }
    }
}
