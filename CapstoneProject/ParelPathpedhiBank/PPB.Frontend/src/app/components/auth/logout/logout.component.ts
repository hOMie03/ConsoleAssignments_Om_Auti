import { Component, OnInit } from '@angular/core';
import { RouterService } from '../../../services/router.service';
import { UserService } from '../../../services/auth/user.service';

@Component({
  selector: 'app-logout',
  standalone: true,
  imports: [],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent implements OnInit {

  constructor(private routerService:RouterService, private userService:UserService) {}
  ngOnInit(): void {
    // Fetch the userID from sessionStorage
    if (typeof window !== 'undefined' && window.sessionStorage) {
      localStorage.clear();
      sessionStorage.removeItem('userID');
      this.userService.updateLoginStatus(false);
      console.log("Logout done. Session now: ", sessionStorage.getItem('userID'));
      // this.routerService.goToLogin();
    }
  }
}
