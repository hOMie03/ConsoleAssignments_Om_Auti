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

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'auth/login', component: LoginComponent},
    {path: 'auth/register', component: RegisterComponent},
    {path: 'auth/logout', component: LogoutComponent},
    {path: 'admin/dashboard', component: AHeaderComponent, canActivate:[adminGuardGuard]},
    {path: 'admin/dashboard/calendar', component: CalendarComponent, canActivate:[adminGuardGuard]},
    {path: 'user/homeboard', component: HomeboardComponent, canActivate:[authGuard]},
    {path: 'user/account/addAccount', component: AddNewAccountComponent, canActivate:[authGuard]},
    {path: 'user/account/yourAccounts', component: YourAccountsComponent, canActivate:[authGuard]}
];
