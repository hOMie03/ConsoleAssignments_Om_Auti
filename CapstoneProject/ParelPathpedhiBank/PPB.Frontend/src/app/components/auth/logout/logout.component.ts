import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-logout',
  standalone: true,
  imports: [],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent implements OnInit {

  ngOnInit(): void {
    // Fetch the userID from sessionStorage
    if (typeof window !== 'undefined' && window.sessionStorage) {
      sessionStorage.removeItem('userID');
      console.log("Logout done. Session now: ", sessionStorage.getItem('userID'));
    }
  }
}
