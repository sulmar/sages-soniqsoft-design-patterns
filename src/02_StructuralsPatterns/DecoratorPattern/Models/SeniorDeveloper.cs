namespace DecoratorPattern
{
    // Concrete Component B
    public class SeniorDeveloper : Employee
    {
        
        public override decimal GetSalary()
        {
            return 2000;
        }
    }

}
