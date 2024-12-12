import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import * as fromPages from './components/pages';
import * as fromAccount from './components/account';
import * as fromDashboardJobs from './components/dashboard/jobs';
import * as fromDashboardCustomers from './components/dashboard/customers';
import * as fromDashboardUsers from './components/dashboard/users';
import * as fromDashboardProducts from './components/dashboard/products';
import * as fromDashboardCampaigns from './components/dashboard/campaigns';
import * as fromDashboardJobUserTasks from './components/dashboard/job-user-tasks';
import * as fromDashboardCampaignUserTasks from './components/dashboard/campaign-user-task';
import {ContactsComponent} from './components/dashboard/contacts/contacts.component';
import {LeadsComponent} from './components/dashboard/leads/leads.component';
import {NotesComponent} from './components/dashboard/notes/notes.component';
import {OrdersComponent} from './components/dashboard/orders/orders.component';
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
          {path: 'job-create', component: fromDashboardJobs.JobCreateComponent},
          {path: 'job-search', component: fromDashboardJobs.JobSearchComponent},
        ]},
      {path: 'job-details/:id', component: fromDashboardJobs.JobDetailsComponent},
      {path: 'campaigns', component: fromDashboardCampaigns.CampaignsComponent, children: [
          {path: 'campaign-create', component: fromDashboardCampaigns.CampaignCreateComponent}
        ]},
      {path: 'campaign-details/:id', component: fromDashboardCampaigns.CampaignDetailComponent},
      {path: 'update-campaign/:id', component: fromDashboardCampaigns.CampaignUpdateComponent},
      {path: 'customers', component: fromDashboardCustomers.CustomersComponent, children: [
          {path: 'customer-create', component: fromDashboardCustomers.CustomerCreateComponent},
          {path: 'customer-search', component: fromDashboardCustomers.CustomerSearchComponent},
        ]},
      {path: 'customer-details/:id', component: fromDashboardCustomers.CustomerDetailComponent},
      {path: 'dashboard-main', component: DashboardMainComponent, children: [
          {path: 'user-list', component: fromDashboardUsers.UserListComponent},
          {path: 'job-list', component: fromDashboardJobs.JobListComponent},
          {path: 'customer-list', component: fromDashboardCustomers.CustomerListComponent},
          {path: 'product-list', component: fromDashboardProducts.ProductListComponent},
          {path: 'campaign-list', component: fromDashboardCampaigns.CampaignListComponent},
        ]},
      {path: 'contacts', component: ContactsComponent},
      {path: 'leads', component: LeadsComponent},
      {path: 'notes', component: NotesComponent},
      {path: 'orders', component: OrdersComponent},
      {path: 'products', component: fromDashboardProducts.ProductsComponent, children: [
          {path: 'product-list', component: fromDashboardProducts.ProductListComponent},
          {path: 'product-create', component: fromDashboardProducts.ProductCreateComponent},
        ]},
      {path: 'product-details/:id', component: fromDashboardProducts.ProductDetailComponent},
      {path: 'tasks', component: TasksComponent},

      {path: 'users', component: fromDashboardUsers.UsersComponent, children: [
          {path: 'user-create', component: fromDashboardUsers.UserCreateComponent},
        ]},
      {path: 'update-user/:id', component: fromDashboardUsers.UserUpdateComponent},
      {path: 'user-details/:id', component: fromDashboardUsers.UserDetailComponent},
      {path: 'campaign-user-tasks', component: fromDashboardCampaignUserTasks.CampaignUserTaskComponent, children: [
          {path: 'view-campaign-user-task/:id', component: fromDashboardCampaignUserTasks.CampaignUserTaskDetailComponent},
          {path: 'update-campaign-user-task/:id', component: fromDashboardCampaignUserTasks.CampaignUserTaskUpdateComponent},
        ]},
      {path: 'job-user-tasks', component: fromDashboardJobUserTasks.JobUserTasksComponent, children: [
        {path: 'view-job-user-task/:id', component: fromDashboardJobUserTasks.JobUserTaskDetailComponent},
          {path: 'update-job-user-task/:id', component: fromDashboardJobUserTasks.JobUserTaskUpdateComponent},
        ]}

    ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
