using System.Collections;
using System.Drawing;
using ConsoleTables;

namespace A1IskandarAbdullaev
{
    internal class Program
    {
        static List<HourlyEmployee> empListHour = new List<HourlyEmployee>();
        static List<CommissionEmployee> empListComm = new List<CommissionEmployee>();
        static List<SalariedEmployee> empListSlry = new List<SalariedEmployee>();
        static List<SalaryPlusCommissionEmployee> empListSlryComm = new List<SalaryPlusCommissionEmployee>();

        static void Main(string[] args)
        {
            HourlyEmployee hemp1 = new HourlyEmployee(1, "John", EmployeeType.HourlyEmployee, 40, 20);
            HourlyEmployee hemp2 = new HourlyEmployee(2, "Wick", EmployeeType.HourlyEmployee, 41, 20);
            HourlyEmployee hemp3 = new HourlyEmployee(9, "Joe", EmployeeType.HourlyEmployee, 42, 20);

            CommissionEmployee cemp1 = new CommissionEmployee(3, "Sarah", EmployeeType.CommissionEmployee, 11, 12);
            CommissionEmployee cemp2 = new CommissionEmployee(4, "Connor", EmployeeType.CommissionEmployee, 15, 12);
            CommissionEmployee cemp3 = new CommissionEmployee(10, "Joe", EmployeeType.CommissionEmployee, 15, 12);

            SalariedEmployee semp1 = new SalariedEmployee(5, "Arnold", EmployeeType.SalariedEmployee, 2000);
            SalariedEmployee semp2 = new SalariedEmployee(6, "Schwarznegger", EmployeeType.SalariedEmployee, 4000);
            SalariedEmployee semp3 = new SalariedEmployee(6, "Joe", EmployeeType.SalariedEmployee, 4000);

            SalaryPlusCommissionEmployee scemp1 = new SalaryPlusCommissionEmployee(7, "Joe", EmployeeType.SalaryPlusCommissionEmployee, 6000, 100, 12);
            SalaryPlusCommissionEmployee scemp2 = new SalaryPlusCommissionEmployee(8, "Biden", EmployeeType.SalaryPlusCommissionEmployee, 8000, 200, 12);


            empListHour.Add(hemp1); empListHour.Add(hemp2); empListHour.Add(hemp3);
            empListComm.Add(cemp1); empListComm.Add(cemp2); empListComm.Add(cemp3);
            empListSlry.Add(semp1); empListSlry.Add(semp2); empListSlry.Add(semp3);
            empListSlryComm.Add(scemp1); empListSlryComm.Add(scemp2);

            // Program runs until user Exits
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n         Assignment1     \n\n      Iskandar Abdullaev\n\n" +
                    "+----------------------------+\n\n" +
                    "   1 - View Employees\n\n" +
                    "   2 - Add Employee\n\n" +
                    "   3 - Remove Employee\n\n" +
                    "   4 - Edit Employee\n\n" +
                    "   5 - Search Employee\n\n" +
                    "   6 - Exit\n\n" +
                    "+----------------------------+\n\n");
                Console.Write("Enter your choice: ");

                int _userInput = Convert.ToInt32(Console.ReadLine().Trim());

                if (_userInput < 1 || _userInput > 6)
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
                else
                {
                    Console.WriteLine("\n\n+----------------------------+\n\n");
                    Console.Clear();
                    switch (_userInput)
                    {
                        case 1:
                            Console.WriteLine("+----------VIEW EMPLOYEES MENU----------+\n");
                            viewAllEmployees(empListHour, empListComm, empListSlry, empListSlryComm);
                            break;
                        case 2:
                            Console.WriteLine("+----------ADD EMPLOYEE MENU----------+\n");
                            addEmployee();
                            break;
                        case 3:
                            Console.WriteLine("+----------REMOVE EMPLOYEE MENU----------+\n");
                            removeEmployee();
                            break;
                        case 4:
                            Console.WriteLine("+----------EDIT EMPLOYEE MENU----------+\n");
                            editEmployees();
                            break;
                        case 5:
                            Console.WriteLine("+----------SEARCH EMPLOYEE MENU----------+\n");
                            findEmployees();
                            break;
                        case 6:
                            Environment.Exit(1);
                            break;
                        default:
                            break;
                    }
                }

                Console.ReadKey();
            }
        }



        /* --------------------------------------- View Employees --------------------------------------- */
        // PRINTS HOUR EMPLOYEE TABLE
        public static void viewHourlyEmployees(List<HourlyEmployee> list)
        {
            var empTableHour = new ConsoleTable("Id", "Name", "Type", "Hours", "Hourly Wage", "Gross Earnings", "Tax (20%)", "Net Earnings");
            foreach (HourlyEmployee e in list)
            {
                Console.Write(e);

                empTableHour.AddRow(e.Id, e.Name, e.employeeType, e.Hours, e.HourlyWage.ToString("C"), e.GrossEarnings.ToString("C"), e.Tax.ToString("C"), e.NetEarnings.ToString("C"));
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Hourly Employees:");
            empTableHour.Write(Format.Alternative);
        }

        // PRINTS COMMISSION EMPLOYEE TABLE
        public static void viewCommissionEmployees(List<CommissionEmployee> list)
        {
            var empTableComm = new ConsoleTable("Id", "Name", "Type", "Sales", "Rate", "Gross Earnings", "Tax (20%)", "Net Earnings");
            foreach (CommissionEmployee e in list)
            {
                Console.Write(e);

                empTableComm.AddRow(e.Id, e.Name, e.employeeType, string.Format("{0:C}", e.GrossSales), string.Format("{0:P}", e.CommRate), string.Format("{0:C}", e.GrossEarnings), string.Format("{0:C}", e.Tax), string.Format("{0:C}", e.NetEarnings));
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Commission Employees:");
            empTableComm.Write(Format.Alternative);
        }

        // PRINTS SALARIED EMPLOYEE TABLE
        public static void viewSalariedEmployees(List<SalariedEmployee> list)
        {
            var empTableSlry = new ConsoleTable("Id", "Name", "Type", "Salary", "Gross Earnings", "Tax (20%)", "Net Earnings");
            foreach (SalariedEmployee e in list)
            {
                Console.Write(e);

                empTableSlry.AddRow(e.Id, e.Name, e.employeeType, string.Format("{0:C}", e.Salary), string.Format("{0:C}", e.GrossEarnings), e.Tax.ToString("C"), string.Format("{0:C}", e.NetEarnings));
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Salaried Employees:");
            empTableSlry.Write(Format.Alternative);
        }

        // PRINTS SALARY + COMMISSION EMPLOYEE TABLE
        public static void viewSalaryPlusCommissionEmployees(List<SalaryPlusCommissionEmployee> list)
        {
            var empTableSlryComm = new ConsoleTable("Id", "Name", "Type", "Salary", "Sales", "Rate", "Gross Earnings", "Tax (20%)", "Net Earnings");
            foreach (SalaryPlusCommissionEmployee e in list)
            {
                Console.Write(e);

                empTableSlryComm.AddRow(e.Id, e.Name, e.employeeType, string.Format("{0:C}", e.Salary), string.Format("{0:C}", e.GrossSales), string.Format("{0:P}", e.CommRate), string.Format("{0:C}", e.GrossEarnings), string.Format("{0:C}", e.Tax), string.Format("{0:C}", e.NetEarnings));
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Salary + Commission Employees:");
            empTableSlryComm.Write(Format.Alternative);
        }

        // Prints all Employees grouped by Pay Type
        public static void viewAllEmployees(List<HourlyEmployee> list1, List<CommissionEmployee> list2, List<SalariedEmployee> list3, List<SalaryPlusCommissionEmployee> list4)
        {
            viewHourlyEmployees(list1);
            viewCommissionEmployees(list2);
            viewSalariedEmployees(list3);
            viewSalaryPlusCommissionEmployees(list4);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to Go Back to Main Menu.");
        }



        /* --------------------------------------- Add Employee ----------------------------------------- */
        // Shows Add Employee Menu and asks for user input for a new employee record to be added
        public static void addEmployee()
        {
            Console.WriteLine("ADD NEW EMPLOYEE\n\n" +
                "    1 - Add Hourly Employee\n" +
                "    2 - Add Commission Employee\n" +
                "    3 - Add Salaried Employee\n" +
                "    4 - Add Salary + Commission Employee\n" +
                "    5 - Back to Main Menu\n");
            Console.Write("Enter your choice: ");

            int _userChoiceAdd = Convert.ToInt32(Console.ReadLine());

            switch (_userChoiceAdd)
            {
                case 1: // Add Hourly employee
                    int _id;
                    string _name;
                    double _hours;
                    double _hourwage;

                    _id = empListHour.Count +
                        empListComm.Count +
                        empListSlry.Count +
                        empListSlryComm.Count + 1;

                    Console.Write("\n\nAdding new [Hourly Employee]: \n");
                    Console.Write("\n    Enter employee name: ");
                    _name = Console.ReadLine();

                    Console.Write("    Enter number of hours worked: ");
                    _hours = Double.Parse(Console.ReadLine());

                    Console.Write("    Enter hourly wage: ");
                    _hourwage = Double.Parse(Console.ReadLine());

                    HourlyEmployee empTempHour = new HourlyEmployee(_id, _name, EmployeeType.HourlyEmployee, _hours, _hourwage);
                    empListHour.Add(empTempHour);

                    Console.WriteLine("\nNew Employee Added.");
                    viewHourlyEmployees(empListHour);
                    break;
                case 2: // Add Commission employee
                    double _sales;
                    double _rate;
                    _id = empListHour.Count +
                        empListComm.Count +
                        empListSlry.Count +
                        empListSlryComm.Count + 1;

                    Console.Write("\n\nAdding new [Commission Employee]: \n");
                    Console.Write("    Enter employee name: ");
                    _name = Console.ReadLine();

                    Console.Write("    Enter sales: ");
                    _sales = Double.Parse(Console.ReadLine());

                    Console.Write("    Enter rate: ");
                    _rate = Double.Parse(Console.ReadLine());

                    CommissionEmployee empTempComm = new CommissionEmployee(_id, _name, EmployeeType.CommissionEmployee, _sales, _rate);
                    empListComm.Add(empTempComm);

                    Console.WriteLine("\nNew Employee Added.");
                    viewCommissionEmployees(empListComm);
                    break;
                case 3: // Add Salaried employee
                    double _salary;
                    _id = empListHour.Count +
                        empListComm.Count +
                        empListSlry.Count +
                        empListSlryComm.Count + 1;

                    Console.Write("\n\nAdding new [Salaried Employee]: \n");
                    Console.Write("    Enter employee name: ");
                    _name = Console.ReadLine();

                    Console.Write("    Enter salary: ");
                    _salary = Double.Parse(Console.ReadLine());

                    SalariedEmployee empTempSlry = new SalariedEmployee(_id, _name, EmployeeType.SalariedEmployee, _salary);
                    empListSlry.Add(empTempSlry);

                    Console.WriteLine("\nNew Employee Added.");
                    viewSalariedEmployees(empListSlry);
                    break;
                case 4: // Add Salary + Commission employee
                    _id = empListHour.Count +
                        empListComm.Count +
                        empListSlry.Count +
                        empListSlryComm.Count + 1;

                    Console.Write("\n\nAdding new [Salary + Commission Employee]: \n");
                    Console.Write("    Enter employee name: ");
                    _name = Console.ReadLine();

                    Console.Write("    Enter salary: ");
                    _salary = Double.Parse(Console.ReadLine());

                    Console.Write("    Enter sales: ");
                    _sales = Double.Parse(Console.ReadLine());

                    Console.Write("    Enter rate: ");
                    _rate = Double.Parse(Console.ReadLine());

                    SalaryPlusCommissionEmployee empTempSlryComm = new SalaryPlusCommissionEmployee(_id, _name, EmployeeType.SalaryPlusCommissionEmployee, _salary, _sales, _rate);
                    empListSlryComm.Add(empTempSlryComm);

                    Console.WriteLine("\nNew Employee Added.");
                    viewSalaryPlusCommissionEmployees(empListSlryComm);
                    break;
                case 5: // Exit to Main Menu
                    Console.WriteLine("Press any key to Go Back to Main Menu.");
                    break;
                default:
                    break;
            }
        }



        /* --------------------------------------- Remove Employee -------------------------------------- */
        // Shows Employee List and asks for user input for an employee record to be deleted
        public static void removeEmployee()
        {
            Console.WriteLine("REMOVE AN EXISTING EMPLOYEE\n\n" +
                "    1 - Remove Hourly Employee\n" +
                "    2 - Remove Commission Employee\n" +
                "    3 - Remove Salaried Employee\n" +
                "    4 - Remove Salary + Commission Employee\n" +
                "    5 - Back to Main Menu\n");
            Console.Write("Enter your choice: ");

            int _userChoiceDelete = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int _empId;
            switch (_userChoiceDelete)
            {
                case 1: // Delete Hourly employee
                    viewHourlyEmployees(empListHour);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Which [Hourly Employee] you want to remove?\nEnter their ID: ");

                    _empId = Int32.Parse(Console.ReadLine());
                    var toRemoveHour = empListHour.SingleOrDefault(e => e.Id == _empId);

                    if (toRemoveHour != null)
                    {
                        empListHour.Remove(empListHour.Single(e => e.Id == _empId));
                        Console.Clear();
                        Console.WriteLine($"The Employee with ID[{_empId}] was removed from the list.\n");
                        viewHourlyEmployees(empListHour);

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nPress any key to Go Back to Main Menu.");
                    }
                    else
                    {
                        Console.WriteLine($"The Employee with ID[{_empId}] does not exist in this list. Try again.");
                    }

                    break;
                case 2: // Delete Commission employee
                    viewCommissionEmployees(empListComm);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Which [Commission Employee] you want to remove?\nEnter their ID: ");

                    _empId = Int32.Parse(Console.ReadLine());

                    var toRemoveComm = empListComm.SingleOrDefault(e => e.Id == _empId);
                    if (toRemoveComm != null)
                    {
                        empListComm.Remove(empListComm.Single(e => e.Id == _empId));
                        Console.Clear();
                        Console.WriteLine($"The Employee with ID[{_empId}] was removed from the list.\n");
                        viewCommissionEmployees(empListComm);

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nPress any key to Go Back to Main Menu.");
                    }
                    else
                    {
                        Console.WriteLine($"The Employee with ID[{_empId}] does not exist in this list. Try again.");
                    }
                    break;
                case 3: // Delete Salaried employee
                    viewSalariedEmployees(empListSlry);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Which [Salaried Employee] you want to remove?\nEnter their ID: ");

                    _empId = Int32.Parse(Console.ReadLine());

                    var toRemoveSlry = empListSlry.SingleOrDefault(e => e.Id == _empId);
                    if (toRemoveSlry != null)
                    {
                        empListSlry.Remove(empListSlry.Single(e => e.Id == _empId));
                        Console.Clear();
                        Console.WriteLine($"The Employee with ID[{_empId}] was removed from the list.\n");
                        viewSalariedEmployees(empListSlry);

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nPress any key to Go Back to Main Menu.");
                    }
                    else
                    {
                        Console.WriteLine($"The Employee with ID[{_empId}] does not exist in this list. Try again.");
                    }
                    break;
                case 4: // Delete Salary + Commission employee
                    viewSalaryPlusCommissionEmployees(empListSlryComm);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Which [Salary + Commission Employee] you want to remove?\nEnter their ID: ");

                    _empId = Int32.Parse(Console.ReadLine());

                    var toRemoveSlryComm = empListSlryComm.SingleOrDefault(e => e.Id == _empId);
                    if (toRemoveSlryComm != null)
                    {
                        empListSlryComm.Remove(empListSlryComm.Single(e => e.Id == _empId));
                        Console.Clear();
                        Console.WriteLine($"The Employee with ID[{_empId}] was removed from the list.\n");
                        viewSalaryPlusCommissionEmployees(empListSlryComm);

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nPress any key to Go Back to Main Menu.");
                    }
                    else
                    {
                        Console.WriteLine($"The Employee with ID[{_empId}] does not exist in this list. Try again.");
                    }

                    break;
                case 5: // Exit to Main Menu
                    Console.WriteLine("Press any key to Go Back to Main Menu.");
                    break;
                default:
                    break;
            }
        }



        /* --------------------------------------- Edit Employees --------------------------------------- */
        // Shows Employee list and asks user for input for an employee record to be modified
        public static void editEmployees()
        {
            Console.WriteLine("EDIT AN EXISTING EMPLOYEE\n\n" +
                "    1 - Edit Hourly Employee\n" +
                "    2 - Edit Commission Employee\n" +
                "    3 - Edit Salaried Employee\n" +
                "    4 - Edit Salary + Commission Employee\n" +
                "    5 - Back to Main Menu\n");
            Console.Write("Enter your choice: ");

            int _userChoiceEdit = Convert.ToInt32(Console.ReadLine());

            switch (_userChoiceEdit)
            {
                case 1:
                    viewHourlyEmployees(empListHour);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Which [Hourly Employee] do you want to edit?\nEnter their ID: ");
                    int _empId = Int32.Parse(Console.ReadLine());

                    var toEditHour = from emp in empListHour
                                     where emp.Id == _empId
                                     select emp;

                    if (toEditHour.Any() != false)
                    {
                        Console.WriteLine($"Editing Employee ID[{_empId}] record:");
                        Console.Write("\n     Enter employee name: ");
                        string _empName = Console.ReadLine();

                        Console.Write("     Enter number of hours worked: ");
                        double _empHours = Double.Parse(Console.ReadLine());

                        Console.Write("     Enter hourly wage: ");
                        double _empHourwage = Double.Parse(Console.ReadLine());


                        foreach (HourlyEmployee he in toEditHour)
                        {
                            he.Id = _empId;
                            he.Name = _empName;
                            he.employeeType = EmployeeType.HourlyEmployee;
                            he.Hours = _empHours;
                            he.HourlyWage = _empHourwage;
                        }
                        viewHourlyEmployees(empListHour);
                    }
                    else
                    {
                        Console.WriteLine($"The Employee with ID[{_empId}] does not exist in this list. Try again.");
                    }

                    break;
                case 2:
                    viewCommissionEmployees(empListComm);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Which [Commission Employee] do you want to edit?\nEnter their ID: ");
                    _empId = Int32.Parse(Console.ReadLine());

                    var toEditComm = from emp in empListComm
                                     where emp.Id == _empId
                                     select emp;

                    if (toEditComm.Any() != false)
                    {
                        Console.WriteLine($"Editing Employee ID[{_empId}] record:");
                        Console.Write("\n     Enter employee name: ");
                        string _empName = Console.ReadLine();

                        Console.Write("     Enter sales: ");
                        double _empSales = Double.Parse(Console.ReadLine());

                        Console.Write("     Enter commmission rate: ");
                        double _empCommRate = Double.Parse(Console.ReadLine());


                        foreach (CommissionEmployee ce in toEditComm)
                        {
                            ce.Id = _empId;
                            ce.Name = _empName;
                            ce.employeeType = EmployeeType.CommissionEmployee;
                            ce.GrossSales = _empSales;
                            ce.CommRate = _empCommRate / 100;
                        }
                        viewCommissionEmployees(empListComm);
                    }
                    else
                    {
                        Console.WriteLine($"The Employee with ID[{_empId}] does not exist in this list. Try again.");
                    }

                    break;
                case 3:
                    viewSalariedEmployees(empListSlry);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Which [Salaried Employee] do you want to edit?\nEnter their ID: ");
                    _empId = Int32.Parse(Console.ReadLine());

                    var toEditSlry = from emp in empListSlry
                                     where emp.Id == _empId
                                     select emp;

                    if (toEditSlry.Any() != false)
                    {
                        Console.WriteLine($"Editing Employee ID[{_empId}] record:");
                        Console.Write("\n     Enter employee name: ");
                        string _empName = Console.ReadLine();

                        Console.Write("     Enter salary: ");
                        double _empSalary = Double.Parse(Console.ReadLine());

                        foreach (SalariedEmployee se in toEditSlry)
                        {
                            se.Id = _empId;
                            se.Name = _empName;
                            se.employeeType = EmployeeType.SalariedEmployee;
                            se.Salary = _empSalary;
                        }
                        viewSalariedEmployees(empListSlry);
                    }
                    else
                    {
                        Console.WriteLine($"The Employee with ID[{_empId}] does not exist in this list. Try again.");
                    }

                    break;
                case 4:
                    viewSalaryPlusCommissionEmployees(empListSlryComm);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Which [Salary + Commission Employee] do you want to edit?\nEnter their ID: ");
                    _empId = Int32.Parse(Console.ReadLine());

                    var toEditSlryComm = from emp in empListSlryComm
                                         where emp.Id == _empId
                                         select emp;

                    if (toEditSlryComm.Any() != false)
                    {
                        Console.WriteLine($"Editing Employee ID[{_empId}] record:");
                        Console.Write("\n     Enter employee name: ");
                        string _empName = Console.ReadLine();

                        Console.Write("     Enter salary: ");
                        double _empSalary = Double.Parse(Console.ReadLine());

                        Console.Write("     Enter sales: ");
                        double _empSales = Double.Parse(Console.ReadLine());

                        Console.Write("     Enter commmission rate: ");
                        double _empCommRate = Double.Parse(Console.ReadLine());

                        foreach (SalaryPlusCommissionEmployee se in toEditSlryComm)
                        {
                            se.Id = _empId;
                            se.Name = _empName;
                            se.employeeType = EmployeeType.SalaryPlusCommissionEmployee;
                            se.Salary = _empSalary;
                            se.GrossSales = _empSales;
                            se.CommRate = _empCommRate / 100;
                        }
                        viewSalaryPlusCommissionEmployees(empListSlryComm);
                    }
                    else
                    {
                        Console.WriteLine($"The Employee with ID[{_empId}] does not exist in this list. Try again.");
                    }
                    break;
                case 5:
                    Console.WriteLine("Press any key to Go Back to Main Menu.");
                    break;
                default: break;
            }
        }



        /* --------------------------------------- Search Employees ------------------------------------- */
        public static void findEmployees()
        {
            string _empName;

            // Asks for name input
            Console.Write("Which Employee do you want to find?\nEnter their Name: ");
            _empName = Console.ReadLine();

            // Creates a group for each Employee type
            var fromEmpHour = from eh in empListHour
                              let uppercaseNames = eh.Name.ToUpper()
                              where uppercaseNames == _empName.ToUpper() && eh.employeeType == EmployeeType.HourlyEmployee
                              select eh;

            var fromEmpComm = from ec in empListComm
                              let uppercaseNames = ec.Name.ToUpper()
                              where uppercaseNames == _empName.ToUpper() && ec.employeeType == EmployeeType.CommissionEmployee
                              select ec;

            var fromEmpSlry = from es in empListSlry
                              let uppercaseNames = es.Name.ToUpper()
                              where uppercaseNames == _empName.ToUpper() && es.employeeType == EmployeeType.SalariedEmployee
                              select es;

            var fromEmpSlryComm = from esc in empListSlryComm
                                  let uppercaseNames = esc.Name.ToUpper()
                                  where uppercaseNames == _empName.ToUpper() && esc.employeeType == EmployeeType.SalaryPlusCommissionEmployee
                                  select esc;

            // Creates tables for each group
            var findEmpHourTable = new ConsoleTable("Id", "Name", "Type", "Hours", "Hourly Wage", "Gross Earnings", "Tax (20%)", "Net Earnings");
            var findEmpCommTable = new ConsoleTable("Id", "Name", "Type", "Sales", "Rate", "Gross Earnings", "Tax (20%)", "Net Earnings");
            var findEmpSlryTable = new ConsoleTable("Id", "Name", "Type", "Salary", "Gross Earnings", "Tax (20%)", "Net Earnings");
            var findEmpSlryCommTable = new ConsoleTable("Id", "Name", "Type", "Salary", "Sales", "Rate", "Gross Earnings", "Tax (20%)", "Net Earnings");



            // Checks if Hour employee search result is empty, if not, stores it into the table
            if (!fromEmpHour.Any())
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"\n>> The Employee with Name[{_empName}] does not exist in [Hour Employee] list.\n");
            }
            else
            {
                Console.WriteLine($"\nThe Employees that match the Name[{_empName}]:\n");

                // Prints Hour employee list
                foreach (HourlyEmployee e in fromEmpHour)
                {
                    Console.Write(e);

                    findEmpHourTable.AddRow(e.Id, e.Name, e.employeeType, e.Hours, e.HourlyWage.ToString("C"), e.GrossEarnings.ToString("C"), e.Tax.ToString("C"), e.NetEarnings.ToString("C"));
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Hourly Employees:");
                findEmpHourTable.Write(Format.Alternative);
            }

            // Checks if Commission employee search result is empty, if not, stores it into the table
            if (!fromEmpComm.Any())
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($">> The Employee with Name[{_empName}] does not exist in [Commission Employee] list.\n");
            }
            else
            {
                // Prints Commission employee list              
                foreach (CommissionEmployee e in fromEmpComm)
                {
                    Console.Write(e);

                    findEmpCommTable.AddRow(e.Id, e.Name, e.employeeType, e.GrossSales.ToString("C"), e.CommRate.ToString("P"), e.GrossEarnings.ToString("C"), e.Tax.ToString("C"), e.NetEarnings.ToString("C"));
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Commission Employees:");
                findEmpCommTable.Write(Format.Alternative);
            }

            // Checks if Salaried employee search result is empty, if not, stores it into the table
            if (!fromEmpSlry.Any())
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($">> The Employee with Name[{_empName}] does not exist in [Salary Employee] list.\n");
            }
            else
            {
                // Prints Salaried employee list
                foreach (SalariedEmployee e in fromEmpSlry)
                {
                    Console.Write(e);

                    findEmpSlryTable.AddRow(e.Id, e.Name, e.employeeType, string.Format("{0:C}", e.Salary), string.Format("{0:C}", e.GrossEarnings), e.Tax.ToString("C"), string.Format("{0:C}", e.NetEarnings));
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Salaried Employees:");
                findEmpSlryTable.Write(Format.Alternative);
            }

            // Checks if Salary + Commission employee search result is empty, if not, stores it into the table
            if (!fromEmpSlryComm.Any())
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($">> The Employee with Name[{_empName}] does not exist in [Salary + Commission Employee] list.\n");
            }
            else
            {
                // Prints Salary + Commission employee list              
                foreach (SalaryPlusCommissionEmployee e in fromEmpSlryComm)
                {
                    Console.Write(e);

                    findEmpSlryCommTable.AddRow(e.Id, e.Name, e.employeeType, e.Salary.ToString("C"), e.GrossSales.ToString("C"), e.CommRate.ToString("P"), e.GrossEarnings.ToString("C"), e.Tax.ToString("C"), e.NetEarnings.ToString("C"));
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Salary + Commission Employees:");
                findEmpSlryCommTable.Write(Format.Alternative);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPress any key to Go Back to Main Menu.");
        }
    }
}