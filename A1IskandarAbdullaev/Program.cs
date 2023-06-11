namespace A1IskandarAbdullaev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("|--------- Hourly Employees ---------|");
            Employee hemp1 = new HourlyEmployee(1, "John", EmployeeType.HourlyEmployee, 20, 50);
            Employee hemp2 = new HourlyEmployee(2, "Wick", EmployeeType.HourlyEmployee, 50, 20);
            Console.WriteLine(hemp1.ToString());
            Console.WriteLine(hemp2.ToString());


            Console.WriteLine("\n|--------- Commission Employees ---------|");
            Employee cemp1 = new CommissionEmployee(3, "Sarah", EmployeeType.CommissionEmployee, 11, 12);
            Employee cemp2 = new CommissionEmployee(4, "Connor", EmployeeType.CommissionEmployee, 15, 12);
            Console.WriteLine(cemp1.ToString());
            Console.WriteLine(cemp2.ToString());

            Console.WriteLine("\n|--------- Salaried Employees ---------|");
            Employee semp1 = new SalariedEmployee(5, "Arnold", EmployeeType.SalariedEmployee, 2000);
            Employee semp2 = new SalariedEmployee(6, "Schwarznegger", EmployeeType.SalariedEmployee, 4000);
            Console.WriteLine(semp1.ToString());
            Console.WriteLine(semp2.ToString());

            Console.WriteLine("\n|--------- Salary+Commission Employees ---------|");
            Employee scemp1 = new SalaryPlusCommissionEmployee(7, "Joe", EmployeeType.SalaryPlusCommissionEmployee, 6000, 100, 12);
            Employee scemp2 = new SalaryPlusCommissionEmployee(8, "Biden", EmployeeType.SalaryPlusCommissionEmployee, 8000, 200, 12);
            Console.WriteLine(scemp1.ToString());
            Console.WriteLine(scemp2.ToString());

            

            Console.ReadKey();
        }

        public viewEmployees()
        {
            for(int i)
        }
    }
}