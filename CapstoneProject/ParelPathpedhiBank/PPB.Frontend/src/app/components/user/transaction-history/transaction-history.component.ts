import { Component } from '@angular/core';
import { Account, DisplayAccount } from '../../../models/user/account';
import { AccountService } from '../../../services/user/account.service';
import { RouterModule } from '@angular/router';
import { Transaction } from '../../../models/user/transaction';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-transaction-history',
  standalone: true,
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './transaction-history.component.html',
  styleUrl: './transaction-history.component.css'
})
export class TransactionHistoryComponent {
  accounts?:DisplayAccount[]=[];
  dispTransactions?:Transaction[];
  transactions: Transaction = new Transaction();
    // newProduct: Product = new Product();
    constructor(private accountService:AccountService)//before angular 18th 
    {
      console.log("this is account component constructor");
    }
    ngOnInit():void{
      console.log("this is ngOnInit method");
      this.getAllAccountsByID();
      this.getUserTransactions();
    }
    userID:string = String(localStorage.getItem('userID'));
    getAllAccountsByID():void {
      this.accountService.getAllAccounts(this.userID).subscribe(res=>{
        console.log(res);
        this.accounts=res;
        }
      )
    }
    // accID?:number = this.transactions.accountID;
    getUserTransactions():void {
      console.log(this.transactions.accountID);
      this.accountService.getUserTransactions(this.transactions.accountID).subscribe(res=>{
        console.log(res);
        this.dispTransactions = res;
      })
    }
}
