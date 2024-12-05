import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import * as fromPages from './components/pages';
import * as fromAccount from './components/account';
import * as fromDashboardJobs from './components/dashboard/jobs';
import * as fromDashboardCustomers from './components/dashboard/customers';
import * as fromDashboardUsers from './components/dashboard/users';
import {CampaignsComponent} from './components/dashboard/campaigns/campaigns.component';
import {ContactsComponent} from './components/dashboard/contacts/contacts.component';
import {LeadsComponent} from './components/dashboard/leads/leads.component';
import {NotesComponent} from './components/dashboard/notes/notes.component';
import {OrdersComponent} from './components/dashboard/orders/orders.component';
import {ProductsComponent} from './components/dashboard/products/products.component';
import {TasksComponent} from './components/dashboard/tasks/tasks.component';
import {DashboardMainComponent} from './components/dashboard/dashboard-main/dashboard-main.component';
import {AccountGuard} from './guards/account-guard.guard';

const routes: Routes = [
  {path: '', component: fromPages.HomeComponent, pathMatch: 'full'},
  {path: 'about', component: fromPages.AboutComponent},
  {path: 'contact', component: fromPages.ContactComponent},
  {path: 'privacy', component: fromPages.PrivacyComponent},
  {path: 'terms', component: fromPages.TermsComponent},
  {path: 'faq', component: fromPages.FaqComponent},
  {path: 'login-page', component: fromAccount.LoginComponent},
  {path: 'register-page', component: fromAccount.RegisterComponent},
  {path: 'dashboard', canActivate: [AccountGuard], children: [
      {path: 'jobs', component: fromDashboardJobs.JobsComponent, children: [
          {path: 'job-calendar', component: fromDashboardJobs.JobCalendarComponent},
          {path: 'job-list', component: fromDashboardJobs.JobListComponent},
          {path: 'job-create', component: fromDashboardJobs.JobCreateComponent},
          {path: 'job-search', component: fromDashboardJobs.JobSearchComponent},
          {path: '', pathMatch: 'full', redirectTo: '/dashboard/jobs/job-calendar'}
        ]},
      {path: 'campaigns', component: CampaignsComponent},
      {path: 'customers', component: fromDashboardCustomers.CustomersComponent, children: [
          {path: 'customer-list', component: fromDashboardCustomers.CustomerListComponent},
          {path: 'customer-create', component: fromDashboardCustomers.CustomerCreateComponent},
          {path: 'customer-search', component: fromDashboardCustomers.CustomerSearchComponent},
          {path: '', pathMatch: 'full', redirectTo: '/dashboard/customers/customer-list'}
        ]},
      {path: 'dashboard-main', component: DashboardMainComponent},
      {path: 'contacts', component: ContactsComponent},
      {path: 'leads', component: LeadsComponent},
      {path: 'notes', component: NotesComponent},
      {path: 'orders', component: OrdersComponent},
      {path: 'products', component: ProductsComponent},
      {path: 'tasks', component: TasksComponent},

      {path: 'users', component: fromDashboardUsers.UsersComponent, children: [
          {path: 'user-list', component: fromDashboardUsers.UserListComponent},
          {path: 'user-create', component: fromDashboardUsers.UserCreateComponent},
          {path: '', pathMatch: 'full', redirectTo: '/dashboard/users/user-list'}
        ]},
      {path: 'user-details/:id', component: fromDashboardUsers.UserDetailComponent},
    ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
