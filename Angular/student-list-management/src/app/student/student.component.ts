import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Student } from './student.model';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {
  students: Student[] = [
    { name: 'Alice', marks: 85, isActive: true },
    { name: 'Bob', marks: 42, isActive: false },
    { name: 'Charlie', marks: 73, isActive: true }
  ];
}

