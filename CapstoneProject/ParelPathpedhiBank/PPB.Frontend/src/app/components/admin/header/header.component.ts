import { Component } from '@angular/core';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-aheader',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class AHeaderComponent {

}
