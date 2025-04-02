import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../../models/user/user';
import { Transaction } from '../../models/user/transaction';
import { DisplayAccount } from '../../models/user/account';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl="https://localhost:7011/api/Admin";

  constructor(private http:HttpClient) { }

  allUsers():Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/GetAllUsers`);
  }
  allTransactions():Observable<Transaction[]> {
    return this.http.get<Transaction[]>(`${this.apiUrl}/GetAllTransactions`);
  }
  allAccounts():Observable<DisplayAccount[]> {
    return this.http.get<DisplayAccount[]>(`${this.apiUrl}/GetAllAccounts`);
  }
}
