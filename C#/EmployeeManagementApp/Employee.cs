using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp
{
    public class Employee
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }

        public Employee(int code, string name, string email, string dept, string location)
        {
            EmpCode = code;
            EmpName = name;
            Email = email;
            DeptName = dept;
            Location = location;
        }

        public void Display()
        {
            Console.WriteLine($"{EmpCode} {EmpName} {Email} {DeptName} {Location}");
        }
    }
}
