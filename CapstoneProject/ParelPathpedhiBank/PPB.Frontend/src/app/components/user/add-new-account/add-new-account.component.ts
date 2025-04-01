import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../../services/user/account.service';
import { Account } from '../../../models/user/account';
import { RouterModule } from '@angular/router';
import { RouterService } from '../../../services/router.service';

@Component({
  selector: 'app-add-new-account',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './add-new-account.component.html',
  styleUrl: './add-new-account.component.css'
})
export class AddNewAccountComponent implements OnInit {
  accounts?:Account[];
  newAccount: Account = new Account();
  d:Date = new Date();
  constructor(private accountService:AccountService, private routerService:RouterService)//before angular 18th 
  {
    this.newAccount.userID = String(localStorage.getItem('userID'));
    this.newAccount.createdDate = new Date();
    console.log("this is addnewaccount component constructor");
  }
  ngOnInit():void{
    console.log("this is ngoninit method");
    this.addAccount();
  }
  addAccount():void{
    this.newAccount.accountType = parseInt(this.newAccount.accountType as unknown as string, 10);
    this.accountService.addAccount(this.newAccount).subscribe(res=>{
      console.log("Successful adding in DB", res);
      this.accounts?.push(res);
      console.log(res.accountType);
      alert("Succesfully created your user account!")
      this.routerService.goToUserDashboard();
    })
  }
}
