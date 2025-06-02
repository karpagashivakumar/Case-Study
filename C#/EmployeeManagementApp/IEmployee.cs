﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp
{
    public interface IEmployee<T> where T : Employee
    {
        string PrintEmployeeDetails(T employee);
    }

}
