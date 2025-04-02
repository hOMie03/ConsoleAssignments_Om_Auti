import { Component } from '@angular/core';
import { DisplayAccount } from '../../../../models/user/account';
import { AdminService } from '../../../../services/admin/admin.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-accounts',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './accounts.component.html',
  styleUrl: './accounts.component.css'
})
export class AccountsComponent {
  accounts?:DisplayAccount[]=[];
  constructor(private adminService:AdminService) { }
  ngOnInit():void{
    console.log("this is ngOnInit method");
    this.getAllAccounts(); 
  }
  userID:string = String(localStorage.getItem('userID'));
  getAllAccounts():void {
    this.adminService.allAccounts().subscribe(res=>{
      console.log(res);
      this.accounts = res;
    });
  }
}
