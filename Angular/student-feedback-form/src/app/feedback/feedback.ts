import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { StudentFeedback } from './feedback.model';

@Component({
  selector: 'app-feedback',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './feedback.html',
  styleUrls: ['./feedback.css']
})
export class FeedbackComponent {
  feedback: StudentFeedback = {
    studentName: '',
    course: 'Angular',
    rating: 1,
    comments: ''
  };

  courses = ['Angular', 'React', 'Vue', 'Node.js'];
}
