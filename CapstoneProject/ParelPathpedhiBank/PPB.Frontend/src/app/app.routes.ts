import { Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { AHeaderComponent } from './components/admin/header/header.component';
import { HomeboardComponent } from './components/user/homeboard/homeboard.component';
import { CalendarComponent } from './components/admin/calendar/calendar.component';
import { LogoutComponent } from './components/auth/logout/logout.component';
import { AddNewAccountComponent } from './components/user/add-new-account/add-new-account.component';
import { YourAccountsComponent } from './components/user/your-accounts/your-accounts.component';
import { authGuard } from './auth.guard';
import { adminGuardGuard } from './admin-guard.guard';
import { TransactionHistoryComponent } from './components/user/transaction-history/transaction-history.component';
import { SendMoneyComponent } from './components/user/send-money/send-money.component';
import { AccountsComponent } from './components/admin/getAll/accounts/accounts.component';
import { TransactionsComponent } from './components/admin/getAll/transactions/transactions.component';
import { UsersComponent } from './components/admin/getAll/users/users.component';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'auth/login', component: LoginComponent},
    {path: 'auth/register', component: RegisterComponent},
    {path: 'auth/logout', component: LogoutComponent},
    {path: 'admin', component: AHeaderComponent, canActivate:[adminGuardGuard]},
    {path: 'admin/dashboard', component: DashboardComponent, canActivate:[adminGuardGuard]},
    {path: 'admin/dashboard/calendar', component: CalendarComponent, canActivate:[adminGuardGuard]},
    {path: 'admin/dashboard/allUsers', component: UsersComponent, canActivate:[adminGuardGuard]},
    {path: 'admin/dashboard/allAccounts', component: AccountsComponent, canActivate:[adminGuardGuard]},
    {path: 'admin/dashboard/allTransactions', component: TransactionsComponent, canActivate:[adminGuardGuard]},
    {path: 'user/homeboard', component: HomeboardComponent, canActivate:[authGuard]},
    {path: 'user/account/addAccount', component: AddNewAccountComponent, canActivate:[authGuard]},
    {path: 'user/account/yourAccounts', component: YourAccountsComponent, canActivate:[authGuard]},
    {path: 'user/account/transactionHistory', component: TransactionHistoryComponent, canActivate:[authGuard]},
    {path: 'user/sendMoney', component: SendMoneyComponent, canActivate:[authGuard]}
];
