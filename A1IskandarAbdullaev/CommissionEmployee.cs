﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;


namespace A1IskandarAbdullaev
{
    public class CommissionEmployee : Employee
    {
        public double GrossSales { get; set; }
        public double CommRate { get; set; }

        public CommissionEmployee(int id, string name, EmployeeType type, double sales, double rate) : base(id, name, type)
        {
            GrossSales = sales;
            CommRate = rate / 100;
        }

        public override double GrossEarnings
        {
            get
            {
                return GrossSales * CommRate;
            }
        }

        public override string ToString()
        {
            return "";
        }
    }
}
