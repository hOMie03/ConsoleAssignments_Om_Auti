import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DisplayAccount } from '../../../models/user/account';
import { Transaction } from '../../../models/user/transaction';
import { AccountService } from '../../../services/user/account.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterService } from '../../../services/router.service';

@Component({
  selector: 'app-send-money',
  standalone: true,
  imports: [RouterModule, FormsModule, CommonModule],
  templateUrl: './send-money.component.html',
  styleUrl: './send-money.component.css'
})
export class SendMoneyComponent {
  accounts?:DisplayAccount[]=[];
    dispTransactions?:Transaction[];
    newTransaction: Transaction = new Transaction();
    toAccountNumber?:number;
      // newProduct: Product = new Product();
      constructor(private accountService:AccountService,private routerService: RouterService)//before angular 18th 
      {
        console.log("this is account component constructor");
        this.newTransaction.date = new Date().toISOString();
      }
      ngOnInit():void{
        console.log("this is ngOnInit method");
        this.getAllAccountsByID();
        this.doTransaction();
      }
      userID:string = String(localStorage.getItem('userID'));
      getAllAccountsByID():void {
        this.accountService.getAllAccounts(this.userID).subscribe(res=>{
          console.log(res);
          this.accounts=res;
          }
        )
      }
      doTransaction():void {
        this.newTransaction.description = this.toAccountNumber + " received " + this.newTransaction.amount + " with the message '" + this.newTransaction.description + "'";
        this.newTransaction.tType = 2;
        console.log(this.newTransaction);
        this.accountService.doTransaction(this.newTransaction).subscribe(res=>{
          console.log(res);
          this.dispTransactions?.push(res);
          alert("Transaction has been done!");
          this.routerService.goToUserDashboard();

        })
      }

}
