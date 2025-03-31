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

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'auth/login', component: LoginComponent},
    {path: 'auth/register', component: RegisterComponent},
    {path: 'auth/logout', component: LogoutComponent},
    {path: 'admin/dashboard', component: AHeaderComponent},
    {path: 'admin/dashboard/calendar', component: CalendarComponent},
    {path: 'user/homeboard', component: HomeboardComponent},
    {path: 'user/account/addAccount', component: AddNewAccountComponent},
];
