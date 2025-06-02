using EmployeeManagementApp;
using System;

class Program
{
    static void Main()
    {
        // Part-Time Employee
        Employee emp1 = new Employee(100, "Scott", "scott@gmail.com", "ODC", "Pune");
        PartTimeEmployee pte = new PartTimeEmployee { Basic = 10000 };
        pte.CalculateSalary();
        Console.WriteLine(pte.PrintEmployeeDetails(emp1));

        // Full-Time Employee
        Employee emp2 = new Employee(101, "Tiger", "tiger@gmail.com", "Hr", "Pune");
        FullTimeEmployee fte = new FullTimeEmployee { Basic = 20000 };
        fte.CalculateSalary();
        Console.WriteLine(fte.PrintEmployeeDetails(emp2));

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
}