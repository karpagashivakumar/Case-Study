// Enum for Course Names
var CourseName;
(function (CourseName) {
    CourseName["Angular"] = "Angular";
    CourseName["NodeJS"] = "Node.js";
    CourseName["FullStack"] = "FullStack";
})(CourseName || (CourseName = {}));
// Class to manage student enrollment
var Student = /** @class */ (function () {
    function Student(name, age, courseName, knowsHTML) {
        this.name = name;
        this.age = age;
        this.courseName = courseName;
        this.knowsHTML = knowsHTML;
    }
    // Method to get course category
    Student.prototype.getCourseCategory = function () {
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
    };
    // Method to validate enrollment
    Student.prototype.getEnrollmentStatus = function () {
        if (this.age < 18) {
            return "Not Eligible";
        }
        if (this.courseName === CourseName.Angular && !this.knowsHTML) {
            return "Not Eligible";
        }
        return "Eligible";
    };
    // Method to display student info
    Student.prototype.displaySummary = function () {
        console.log("Student Name: ".concat(this.name));
        console.log("Age: ".concat(this.age));
        console.log("Course: ".concat(this.courseName));
        console.log("Knows HTML: ".concat(this.knowsHTML));
        console.log("Course Category: ".concat(this.getCourseCategory()));
        console.log("Enrollment Status: ".concat(this.getEnrollmentStatus()));
        console.log("------------------------");
    };
    return Student;
}());
// Sample student data
var students = [
    new Student("Sneha", 20, CourseName.Angular, true),
    new Student("Karan", 17, CourseName.NodeJS, false),
    new Student("Riya", 22, CourseName.Angular, false),
    new Student("Aman", 25, CourseName.FullStack, true)
];
// Display enrollment summary for each student
for (var _i = 0, students_1 = students; _i < students_1.length; _i++) {
    var student = students_1[_i];
    student.displaySummary();
}
