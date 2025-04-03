import { Component } from '@angular/core';
import { RouterService } from '../../../services/router.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-successful-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './successful-login.component.html',
  styleUrl: './successful-login.component.css'
})
export class SuccessfulLoginComponent {
  adminCheck:string = String(localStorage.getItem('email'));
}
