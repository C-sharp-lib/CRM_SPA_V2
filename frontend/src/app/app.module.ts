import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import * as fromMain from './components/main';
import * as fromPages from './components/pages';
import * as fromAccount from './components/account';
import * as fromServices from './services';
import {NgOptimizedImage} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {provideHttpClient, withFetch} from '@angular/common/http';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { JobsComponent } from './components/dashboard/jobs/jobs.component';
import { CampaignsComponent } from './components/dashboard/campaigns/campaigns.component';
import { NotesComponent } from './components/dashboard/notes/notes.component';
import { ProductsComponent } from './components/dashboard/products/products.component';
import { OrdersComponent } from './components/dashboard/orders/orders.component';
import { ContactsComponent } from './components/dashboard/contacts/contacts.component';
import { LeadsComponent } from './components/dashboard/leads/leads.component';
import { TasksComponent } from './components/dashboard/tasks/tasks.component';
import { CustomersComponent } from './components/dashboard/customers/customers.component';
import { UsersComponent } from './components/dashboard/users/users.component';
import { JobCalendarComponent } from './components/dashboard/jobs/job-calendar/job-calendar.component';
import { JobListComponent } from './components/dashboard/jobs/job-list/job-list.component';
import { JobCreateComponent } from './components/dashboard/jobs/job-create/job-create.component';
import { JobSearchComponent } from './components/dashboard/jobs/job-search/job-search.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import { CustomerCreateComponent } from './components/dashboard/customers/customer-create/customer-create.component';
import { CustomerListComponent } from './components/dashboard/customers/customer-list/customer-list.component';
import { CustomerDetailComponent } from './components/dashboard/customers/customer-detail/customer-detail.component';
import { CustomerSearchComponent } from './components/dashboard/customers/customer-search/customer-search.component';
import { JobDetailsComponent } from './components/dashboard/jobs/job-detail/job-details.component';
import { DashboardMainComponent } from './components/dashboard/dashboard-main/dashboard-main.component'; // the main connector



@NgModule({
  declarations: [
    AppComponent,
    ...fromMain.components,
    ...fromPages.components,
    ...fromAccount.components,
    DashboardComponent,
    JobsComponent,
    CampaignsComponent,
    NotesComponent,
    ProductsComponent,
    OrdersComponent,
    ContactsComponent,
    LeadsComponent,
    TasksComponent,
    CustomersComponent,
    UsersComponent,
    JobCalendarComponent,
    JobListComponent,
    JobCreateComponent,
    JobSearchComponent,
    CustomerCreateComponent,
    CustomerListComponent,
    CustomerDetailComponent,
    CustomerSearchComponent,
    JobDetailsComponent,
    DashboardMainComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgOptimizedImage,
    FormsModule,
    FullCalendarModule,
    ReactiveFormsModule
  ],
  providers: [
    provideClientHydration(),
    provideHttpClient(withFetch()),
    ...fromServices.services
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
