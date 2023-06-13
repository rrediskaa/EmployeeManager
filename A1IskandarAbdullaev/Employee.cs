using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace A1IskandarAbdullaev
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeType employeeType { get; set; }

        public abstract double GrossEarnings { get; }
        public double Tax { get { return GrossEarnings * 0.2; } }
        public double NetEarnings { get { return GrossEarnings - Tax; } }

        public Employee(int id, string name, EmployeeType type)
        {
            Id = id; Name = name; employeeType = type;
        }
        
        public override string ToString()
        {
            return "";
        }
    }
}
