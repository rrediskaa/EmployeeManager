using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;


namespace A1IskandarAbdullaev
{
    public class HourlyEmployee : Employee
    {
        public double Hours { get; set; }
        public double HourlyWage { get; set; }

        public HourlyEmployee(int id, string name, EmployeeType type, double hours, double hourwage) : base(id, name, type)
        {
            Hours = hours;
            HourlyWage = hourwage;
        }

        public override double GrossEarnings
        {
            get
            {
                if (Hours <= 40)
                {
                    return HourlyWage * Hours;
                }
                else
                {
                    return (40 * HourlyWage) + (Hours - 40) * HourlyWage * 1.5;
                }

            }
        }

        public override string ToString()
        {
            return $"";
        }
    }
}
