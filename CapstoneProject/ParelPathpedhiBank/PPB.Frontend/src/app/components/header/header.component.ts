import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Session } from 'inspector';
import { UserService } from '../../services/auth/user.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  userID: string | null = null;
  // isLoggedIn:boolean = true;
  // email:string | null = '';

  constructor(private userService:UserService) {}

  ngOnInit(): void {
    // Fetch the userID from sessionStorage
    if (typeof window !== 'undefined' && window.sessionStorage) {
      this.userID = sessionStorage.getItem('userID');
    }
    // this.userService.isLoggedIn$.subscribe((loggedIn) => {
    //   this.isLoggedIn = loggedIn;
    //   this.email = localStorage.getItem('email');
    // })
  }
}
