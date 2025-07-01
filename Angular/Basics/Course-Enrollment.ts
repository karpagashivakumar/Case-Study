// Enum for Course Names
enum CourseName {
    Angular = "Angular",
    NodeJS = "Node.js",
    FullStack = "FullStack"
}

// Interface for Student
interface IStudent {
    name: string;
    age: number;
    courseName: CourseName;
    knowsHTML: boolean;
}

// Class to manage student enrollment
class Student implements IStudent {
    name: string;
    age: number;
    courseName: CourseName;
    knowsHTML: boolean;

    constructor(name: string, age: number, courseName: CourseName, knowsHTML: boolean) {
        this.name = name;
        this.age = age;
        this.courseName = courseName;
        this.knowsHTML = knowsHTML;
    }

    // Method to get course category
    getCourseCategory(): string {
        switch (this.courseName) {
            case CourseName.Angular:
                return "Front-End";
            case CourseName.NodeJS:
                return "Back-End";
            case CourseName.FullStack:
                return "Full-Stack";
            default:
                return "Unknown";
        }
    }

    // Method to validate enrollment
    getEnrollmentStatus(): string {
        if (this.age < 18) {
            return "Not Eligible";
        }
        if (this.courseName === CourseName.Angular && !this.knowsHTML) {
            return "Not Eligible";
        }
        return "Eligible";
    }

    // Method to display student info
    displaySummary(): void {
        console.log(`Student Name: ${this.name}`);
        console.log(`Age: ${this.age}`);
        console.log(`Course: ${this.courseName}`);
        console.log(`Knows HTML: ${this.knowsHTML}`);
        console.log(`Course Category: ${this.getCourseCategory()}`);
        console.log(`Enrollment Status: ${this.getEnrollmentStatus()}`);
        console.log("------------------------");
    }
}

// Sample student data
const students: Student[] = [
    new Student("Sneha", 20, CourseName.Angular, true),
    new Student("Karan", 17, CourseName.NodeJS, false),
    new Student("Riya", 22, CourseName.Angular, false),
    new Student("Aman", 25, CourseName.FullStack, true)
];

// Display enrollment summary for each student
for (const student of students) {
    student.displaySummary();
}
