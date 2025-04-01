import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Account } from '../../models/user/account';
import { Observable } from 'rxjs';
import { Transaction } from '../../models/user/transaction';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);

  constructor() { }

  getAllAccounts(userID:string):Observable<Account[]>{
    return this.http.get<Account[]>(`https://localhost:7011/api/Account/${userID}`);
  }
  addAccount(account: Account): Observable<Account> {
    return this.http.post<Account>('https://localhost:7011/api/Account/AddAccount', account);
  }
  deleteAccount(userID:string, accountNumber?:string): Observable<Account> {
    return this.http.delete<Account>(`https://localhost:7011/api/Account/DeleteAccount?userID=${userID}&accNo=${accountNumber}`);
  }
  getUserTransactions(accID?:number): Observable<Transaction[]>{
    return this.http.get<Transaction[]>(`https://localhost:7011/api/Transaction/${accID}`);
  }
  doTransaction(transaction:Transaction): Observable<Transaction> {
    return this.http.post<Transaction>('https://localhost:7011/api/Transaction/DoTransaction', transaction);
  }
}
