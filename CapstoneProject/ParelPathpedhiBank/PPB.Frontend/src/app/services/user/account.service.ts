import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Account } from '../../models/user/account';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);

  constructor() { }

  getAllAccounts():Observable<Account[]>{
    return this.http.get<Account[]>('https://localhost:7011/api/Account')
  }
  addAccount(account: Account): Observable<Account> {
    return this.http.post<Account>('https://localhost:7011/api/Account/AddAccount', account);
 }
}
