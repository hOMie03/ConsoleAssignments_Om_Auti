import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../../services/user/account.service';
import { Account } from '../../../models/user/account';
import { RouterModule } from '@angular/router';

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
  constructor(private accountService:AccountService)//before angular 18th 
  {
    console.log("this is addnewaccount component constructor");
  }
  ngOnInit():void{
    console.log("this is ngoninit method");
    // this.getAllSccounts();
    this.addAccount();
  }
  // getAllAccounts():void {
  //   this.accountService.getAllAccounts().subscribe(res=>{
  //     console.log(res);
  //     this.accounts=res;
  //     }
  //   )
  // }
  addAccount():void{
    this.accountService.addAccount(this.newAccount).subscribe(res=>{
      console.log(res);
      this.accounts?.push(res);
    })
  }
  
}
