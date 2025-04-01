import { Component } from '@angular/core';
import { DisplayAccount } from '../../../models/user/account';
import { AccountService } from '../../../services/user/account.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-your-accounts',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './your-accounts.component.html',
  styleUrl: './your-accounts.component.css'
})
export class YourAccountsComponent {
  accounts?:DisplayAccount[]=[];
  // newProduct: Product = new Product();
  constructor(private accountService:AccountService)//before angular 18th 
  {
    console.log("this is account component constructor");
  }
  ngOnInit():void{
    console.log("this is ngOnInit method");
    this.getAllProducts();
      
  }
  userID:string = String(localStorage.getItem('userID'));
  getAllProducts():void {
    this.accountService.getAllAccounts(this.userID).subscribe(res=>{
      console.log(res);
      this.accounts=res;
      }
    )
  }
  // updateAccount(account:Account) {
  //   console.log(account);
  // }
}
