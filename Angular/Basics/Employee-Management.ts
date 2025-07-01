// Enum for Departments
enum Department {
    HR = "HR",
    IT = "IT",
    Sales = "Sales"
}

// Interface for Employee structure
interface IEmployee {
    name: string;
    age: number;
    department: Department;
    baseSalary: number;
}

// Class to manage employee data and operations
class Employee implements IEmployee {
    name: string;
    age: number;
    department: Department;
    baseSalary: number;

    constructor(name: string, age: number, department: Department, baseSalary: number) {
        this.name = name;
        this.age = age;
        this.department = department;
        this.baseSalary = baseSalary;
    }

    // Method to calculate bonus based on department
    private getBonusRate(): number {
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
    }

    // Method to get net salary
    getNetSalary(): number {
        return this.baseSalary + (this.baseSalary * this.getBonusRate());
    }

    // Method to categorize employee based on salary
    getCategory(): string {
        const netSalary = this.getNetSalary();
        if (netSalary >= 80000) {
            return "High Earner";
        } else if (netSalary >= 50000) {
            return "Mid Earner";
        } else {
            return "Low Earner";
        }
    }

    // Display employee details
    displayInfo(): void {
        console.log(`Employee Name: ${this.name}`);
        console.log(`Age: ${this.age}`);
        console.log(`Department: ${this.department}`);
        console.log(`Base Salary: ₹${this.baseSalary}`);
        console.log(`Net Salary (with bonus): ₹${this.getNetSalary()}`);
        console.log(`Category: ${this.getCategory()}`);
        console.log("------------------------");
    }
}

// Sample employees
const employees: Employee[] = [
    new Employee("Ravi", 28, Department.IT, 60000),
    new Employee("Priya", 32, Department.HR, 48000),
    new Employee("Arjun", 26, Department.Sales, 85000)
];

// Display all employee info
for (const emp of employees) {
    emp.displayInfo();
}
