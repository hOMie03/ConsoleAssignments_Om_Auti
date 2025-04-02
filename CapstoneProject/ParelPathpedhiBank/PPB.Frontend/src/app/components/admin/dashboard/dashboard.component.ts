import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CalendarComponent } from '../calendar/calendar.component';
import { AHeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterOutlet, AHeaderComponent, CalendarComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

}
