﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp
{
    public interface IPartTimeEmployee : IEmployee<Employee>
    {
        double Basic { get; set; }
        double Da { get; set; }
        double NetSalary { get; set; }

        double CalculateSalary();
    }

}
