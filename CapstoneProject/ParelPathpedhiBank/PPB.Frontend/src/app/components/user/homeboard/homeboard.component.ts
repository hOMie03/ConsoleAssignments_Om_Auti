import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-homeboard',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './homeboard.component.html',
  styleUrl: './homeboard.component.css'
})
export class HomeboardComponent {
  email?:string | null = localStorage.getItem('email');
}
