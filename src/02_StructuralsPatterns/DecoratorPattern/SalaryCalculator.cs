using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{

   

    // Abstract Component
    public abstract class File
    {
        public string Content { get; set; }

        public abstract void Process();
    }

    // Concrete Component
    public class CsvFile : File
    {
        public override void Process()
        {
            
        }
    }

    public abstract class FileDecorator : File
    {
        protected File file;

        protected FileDecorator(File file)
        {
            this.file = file;
        }

        public override void Process()
        {
            if (file != null)
            {
                this.file.Process();
            }
        }


    }

    public class CompressFileDecorator : FileDecorator
    {
        public CompressFileDecorator(File file) : base(file)
        {
        }

        public override void Process()
        {
            file.Content += "!";

            base.Process();
        }
    }

    public class EncryptFileDecorator : FileDecorator
    {
        public EncryptFileDecorator(File file) : base(file)
        {
        }

        public override void Process()
        {
            file.Content = "!^%#$##$#$#$#";

            base.Process();
        }
    }


    // Kalkulator płacowy 
    // Premia za nadgodziny
    // Premia za oddanie każdego projektu
    // Premia za udział w szkoleniu ;-)

    public class SalaryCalculator
    {
        public SalaryCalculator()
        {
            
        }

        public decimal CalculateSalary(Employee employee)
        {
            // pensja zasadnicza
            decimal salary = employee.GetSalary();

            // premia za nadgodziny
           // salary += (decimal) employee.OvertimeSalary.TotalHours * amountPerHour;


            // premia za oddanie każdego projektu
            //for (int i = 0; i < employee.NumberOfProjects; i++)
            //{
            //    salary += bonusPerProject;
            //}

            

            // premia za udział w szkoleniu
            // etc. ...

            return salary;           
           
        }
    }

}
