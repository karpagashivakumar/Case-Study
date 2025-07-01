// Enum for Departments
var Department;
(function (Department) {
    Department["HR"] = "HR";
    Department["IT"] = "IT";
    Department["Sales"] = "Sales";
})(Department || (Department = {}));
// Class to manage employee data and operations
var Employee = /** @class */ (function () {
    function Employee(name, age, department, baseSalary) {
        this.name = name;
        this.age = age;
        this.department = department;
        this.baseSalary = baseSalary;
    }
    // Method to calculate bonus based on department
    Employee.prototype.getBonusRate = function () {
        switch (this.department) {
            case Department.HR:
                return 0.10;
            case Department.IT:
                return 0.15;
            case Department.Sales:
                return 0.12;
            default:
                return 0;
        }
    };
    // Method to get net salary
    Employee.prototype.getNetSalary = function () {
        return this.baseSalary + (this.baseSalary * this.getBonusRate());
    };
    // Method to categorize employee based on salary
    Employee.prototype.getCategory = function () {
        var netSalary = this.getNetSalary();
        if (netSalary >= 80000) {
            return "High Earner";
        }
        else if (netSalary >= 50000) {
            return "Mid Earner";
        }
        else {
            return "Low Earner";
        }
    };
    // Display employee details
    Employee.prototype.displayInfo = function () {
        console.log("Employee Name: ".concat(this.name));
        console.log("Age: ".concat(this.age));
        console.log("Department: ".concat(this.department));
        console.log("Base Salary: \u20B9".concat(this.baseSalary));
        console.log("Net Salary (with bonus): \u20B9".concat(this.getNetSalary()));
        console.log("Category: ".concat(this.getCategory()));
        console.log("------------------------");
    };
    return Employee;
}());
// Sample employees
var employees = [
    new Employee("Ravi", 28, Department.IT, 60000),
    new Employee("Priya", 32, Department.HR, 48000),
    new Employee("Arjun", 26, Department.Sales, 85000)
];
// Display all employee info
for (var _i = 0, employees_1 = employees; _i < employees_1.length; _i++) {
    var emp = employees_1[_i];
    emp.displayInfo();
}
