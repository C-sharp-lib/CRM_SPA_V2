import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import * as fromPages from './components/pages';
import * as fromAccount from './components/account';
import {JobsComponent} from './components/dashboard/jobs/jobs.component';
import {CampaignsComponent} from './components/dashboard/campaigns/campaigns.component';
import {CustomersComponent} from './components/dashboard/customers/customers.component';
import {ContactsComponent} from './components/dashboard/contacts/contacts.component';
import {LeadsComponent} from './components/dashboard/leads/leads.component';
import {NotesComponent} from './components/dashboard/notes/notes.component';
import {OrdersComponent} from './components/dashboard/orders/orders.component';
import {ProductsComponent} from './components/dashboard/products/products.component';
import {TasksComponent} from './components/dashboard/tasks/tasks.component';
import {UsersComponent} from './components/dashboard/users/users.component';
import {JobCalendarComponent} from './components/dashboard/jobs/job-calendar/job-calendar.component';
import {JobSearchComponent} from './components/dashboard/jobs/job-search/job-search.component';
import {JobCreateComponent} from './components/dashboard/jobs/job-create/job-create.component';
import {JobListComponent} from './components/dashboard/jobs/job-list/job-list.component';
import {CustomerListComponent} from './components/dashboard/customers/customer-list/customer-list.component';
import {CustomerCreateComponent} from './components/dashboard/customers/customer-create/customer-create.component';
import {CustomerSearchComponent} from './components/dashboard/customers/customer-search/customer-search.component';
import {DashboardMainComponent} from './components/dashboard/dashboard-main/dashboard-main.component';

const routes: Routes = [
  {path: '', component: fromPages.HomeComponent, pathMatch: 'full'},
  {path: 'about', component: fromPages.AboutComponent},
  {path: 'contact', component: fromPages.ContactComponent},
  {path: 'login-page', component: fromAccount.LoginComponent},
  {path: 'register-page', component: fromAccount.RegisterComponent},
  {path: 'dashboard', children: [
      {path: 'jobs', component: JobsComponent, children: [
          {path: 'job-calendar', component: JobCalendarComponent},
          {path: 'job-list', component: JobListComponent},
          {path: 'job-create', component: JobCreateComponent},
          {path: 'job-search', component: JobSearchComponent},
          {path: '', pathMatch: 'full', redirectTo: '/dashboard/jobs/job-calendar'}
        ]},
      {path: 'campaigns', component: CampaignsComponent},
      {path: 'customers', component: CustomersComponent, children: [
          {path: 'customer-list', component: CustomerListComponent},
          {path: 'customer-create', component: CustomerCreateComponent},
          {path: 'customer-search', component: CustomerSearchComponent},
          {path: '', pathMatch: 'full', redirectTo: '/dashboard/customers/customer-list'}
        ]},
      {path: 'dashboard-main', component: DashboardMainComponent},
      {path: 'contacts', component: ContactsComponent},
      {path: 'leads', component: LeadsComponent},
      {path: 'notes', component: NotesComponent},
      {path: 'orders', component: OrdersComponent},
      {path: 'products', component: ProductsComponent},
      {path: 'tasks', component: TasksComponent},
      {path: 'users', component: UsersComponent},
    ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
