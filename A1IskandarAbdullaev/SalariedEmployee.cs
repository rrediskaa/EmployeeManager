using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1IskandarAbdullaev
{
    public class SalariedEmployee :Employee
    {
        public double Salary { get; set; }

        public SalariedEmployee(int id, string name, EmployeeType type, double salary) : base(id, name, type)
        {
            Salary = salary;
        }

        public override double GrossEarnings
        {
            get
            {
                return Salary;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nGross Earnings: {GrossEarnings}/week\n";
        }
    }
}
