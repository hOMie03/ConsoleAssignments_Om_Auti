import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Transaction } from '../../../../models/user/transaction';
import { AdminService } from '../../../../services/admin/admin.service';

@Component({
  selector: 'app-transactions',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './transactions.component.html',
  styleUrl: './transactions.component.css'
})
export class TransactionsComponent {
  dispTransactions?:Transaction[]=[];
  constructor(private adminService:AdminService) { }
  ngOnInit() {
    this.getAllTransactions();
  }
  getAllTransactions():void {
    this.adminService.allTransactions().subscribe(res=>{
      console.log(res);
      this.dispTransactions = res;
    });
  }
}
