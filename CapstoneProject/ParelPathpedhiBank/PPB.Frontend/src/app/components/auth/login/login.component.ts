import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { UserService } from '../../../services/auth/user.service';
import { AuthResponseModel, Login } from '../../../models/auth/login';
import { Router } from '@angular/router';
import { RouterService } from '../../../services/router.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginModel:Login=new Login('','');
  errorMsg='';
  constructor(private userService:UserService, private routerService: RouterService){}
  ngonInit(){
    // this.loginUser();
  }
  loginUser(loginForm:NgForm){

    this.loginModel=loginForm.value;
    console.log(this.loginModel);

    this.userService.login(this.loginModel).subscribe({
      next:(response:AuthResponseModel)=>{
        console.log('Login Success',response);

        localStorage.setItem('token',response.token);
        localStorage.setItem('userID',response.id);
        localStorage.setItem('email',response.email);
        this.userService.updateLoginStatus(true);
        alert('LoginSuccess');
        sessionStorage.setItem('userID', response.id);
        console.log("Session created", sessionStorage.getItem('userID'));
        // loginForm.reset();
        
        if(this.loginModel.email == "om@admin.com")
        {
          this.routerService.goToAdminDashboard();
        }
        else
        {
          this.routerService.goToUserboard();
        }
      }, error:(error)=>{
        console.error('LoginFailed',error);
        this.errorMsg=JSON.stringify(error.error);
        alert(this.errorMsg);
      }
    });
  }

}
