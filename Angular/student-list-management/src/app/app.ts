import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StudentComponent } from './student/student.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, StudentComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'student-list-management';
}
