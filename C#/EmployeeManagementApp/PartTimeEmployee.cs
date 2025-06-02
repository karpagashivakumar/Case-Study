using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp
{
    public class PartTimeEmployee : IPartTimeEmployee
    {
        public double Basic { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Da = Basic * 0.05;
            NetSalary = Basic + Da;
            return NetSalary;
        }

        public string PrintEmployeeDetails(Employee employee)
        {
            employee.Display();
            return $"Net Salary For Part Time Employee is:{NetSalary}";
        }
    }
}
