import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { HeaderComponent } from './components/header/header.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { AHeaderComponent } from './components/admin/header/header.component';
import { HomeboardComponent } from './components/user/homeboard/homeboard.component';
import { CalendarComponent } from './components/admin/calendar/calendar.component';
import { LogoutComponent } from './components/auth/logout/logout.component';
import { AddNewAccountComponent } from './components/user/add-new-account/add-new-account.component';
import { YourAccountsComponent } from './components/user/your-accounts/your-accounts.component';
import { TransactionHistoryComponent } from './components/user/transaction-history/transaction-history.component';
import { SendMoneyComponent } from './components/user/send-money/send-money.component';
import { AccountsComponent } from './components/admin/getAll/accounts/accounts.component';
import { TransactionsComponent } from './components/admin/getAll/transactions/transactions.component';
import { UsersComponent } from './components/admin/getAll/users/users.component';
import { SuccessfulLoginComponent } from './components/auth/successful-login/successful-login.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, FooterComponent,
            HomeComponent, LoginComponent, RegisterComponent, LogoutComponent, SuccessfulLoginComponent,
            AHeaderComponent, DashboardComponent, CalendarComponent,
            AccountsComponent, TransactionsComponent, UsersComponent,
            HomeboardComponent,
            AddNewAccountComponent, YourAccountsComponent, TransactionHistoryComponent, SendMoneyComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Parel Pathpedhi Bank';
}
