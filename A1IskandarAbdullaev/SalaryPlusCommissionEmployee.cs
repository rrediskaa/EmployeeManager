using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1IskandarAbdullaev
{
    public class SalaryPlusCommissionEmployee : CommissionEmployee
    {
        public double Salary { get; set; }

        public SalaryPlusCommissionEmployee(int id, string name, EmployeeType type, double salary, double sales, double rate) : base(id, name, type, sales, rate)
        {
            Salary = salary;
        }

        public override double GrossEarnings
        {
            get
            {
                return Salary + base.GrossSales * base.CommRate;
            }
        }
    }
}
