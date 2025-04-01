import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RouterService {

  constructor(private router:Router) { }

  goToUserboard(){
    this.router.navigate(['/user/homeboard']);
  }
  goToLogin(){
    this.router.navigate(['/auth/login']);
  }
  goToAdminDashboard() {
    this.router.navigate(['/admin/dashboard']);
  }

  // After deleting
  goToUserDashboard() {
    this.router.navigate(['/user/homeboard']);
  }
}
