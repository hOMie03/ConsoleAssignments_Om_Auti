import { Component } from '@angular/core';
import { DisplayAccount } from '../../../models/user/account';
import { AccountService } from '../../../services/user/account.service';
import { RouterModule } from '@angular/router';
import { RouterService } from '../../../services/router.service';

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
  constructor(private accountService:AccountService, private routerService:RouterService)//before angular 18th 
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
  // deleteAccount(accountNumber?:string) {
  //   console.log(accountNumber);
  //   this.accountService.deleteAccount(this.userID, accountNumber).subscribe(res=>{
  //     console.log(res);
  //     alert("Your account has been deleted successfully!");
  //     this.routerService.goToUserDashboard();
  //   })
  // }
}
