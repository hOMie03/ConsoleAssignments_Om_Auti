import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthResponseModel, Login } from '../../models/auth/login';
import { Observable } from 'rxjs';
import { Register, RegistrationResponseModel } from '../../models/auth/register';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl="https://localhost:7011/api/Auth";
  
  constructor(private http:HttpClient) { }

  login(loginData:Login):Observable<AuthResponseModel> {
    return this.http.post<AuthResponseModel>(`${this.apiUrl}/login`,loginData);
  }

  register(user:Register):Observable<RegistrationResponseModel> {
    return this.http.post<RegistrationResponseModel>(`${this.apiUrl}/register`,user);
  }

  isLoggedIn():boolean{
    return !!localStorage.getItem('token');
  }
  checkAdmin():boolean {
    if(localStorage.getItem('email') == "om@admin.com")
    {
      return true;
    }
    return false;
  }
}
