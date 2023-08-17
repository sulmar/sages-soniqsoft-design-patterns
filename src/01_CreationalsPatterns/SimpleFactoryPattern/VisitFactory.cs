using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
{
    public class VisitFactory
    {
        public static Visit Create(string kind, TimeSpan duration, decimal pricePerHour)
        {
            switch (kind)
            {
                case "N": return new NfzVisit(duration, pricePerHour);
                case "P": return new PrivateVisit(duration, pricePerHour);
                case "F": return new CompanyVisit(duration, pricePerHour);
                case "T": return new TeleVisit(duration, pricePerHour);

                default:
                    throw new NotSupportedException();
            }
        }
    }

    public class ColorFactory
    {
        public static ConsoleColor Create(decimal amount)
        {
            switch (amount)
            {
                case 0:
                    return ConsoleColor.Green;
                case >= 200:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.White;
            }
        }
    }

}
