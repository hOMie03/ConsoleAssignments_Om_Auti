import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../../services/auth/user.service';
import { Register } from '../../../models/auth/register';
import { Router, RouterModule } from '@angular/router';
import { response } from 'express';
import { CommonModule } from '@angular/common';
import { RouterService } from '../../../services/router.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, FormsModule, RouterModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  errorMsg = '';

  constructor(private userService:UserService, private fb:FormBuilder, private routerService: RouterService) {

  }
  ngOnInit() {
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }
  registerUser(user:FormGroup) {
    this.userService.register(user.value).subscribe({
      next: (response) => {
        console.log(response);
        alert("Registration Success");
        // this.registerForm?.reset();
        this.routerService.goToLogin();

      },
      error: (err) => {
        console.error('Registration Failed:', err);
        this.errorMsg = JSON.stringify(err.error.message);
        alert(this.errorMsg);
      }
    });
  }
}
