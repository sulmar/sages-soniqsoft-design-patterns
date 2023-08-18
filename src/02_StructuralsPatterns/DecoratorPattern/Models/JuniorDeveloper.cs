namespace DecoratorPattern
{

    // Concrete Component A
    public class JuniorDeveloper : Employee
    {
        public override decimal GetSalary()
        {
            return 1000;
        }
    }

}
