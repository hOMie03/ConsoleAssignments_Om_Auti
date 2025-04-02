import { Component } from '@angular/core';
import { User } from '../../../../models/user/user';
import { AdminService } from '../../../../services/admin/admin.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent {
  users?:User[]=[];
  constructor(private adminService:AdminService) { }
  ngOnInit() {
    this.getAllUsers();
  }
  getAllUsers():void {
    this.adminService.allUsers().subscribe(res=>{
      console.log(res);
      this.users = res;
      
    });
  }
}
