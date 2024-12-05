import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import {provideHttpClient, withFetch} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {NgOptimizedImage} from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import * as fromMain from './components/main';
import * as fromPages from './components/pages';
import * as fromAccount from './components/account';
import * as fromDashboardJobs from './components/dashboard/jobs';
import * as fromDashboardCustomers from './components/dashboard/customers';
import * as fromDashboardUsers from './components/dashboard/users';
import * as fromServices from './services';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CampaignsComponent } from './components/dashboard/campaigns/campaigns.component';
import { NotesComponent } from './components/dashboard/notes/notes.component';
import { ProductsComponent } from './components/dashboard/products/products.component';
import { OrdersComponent } from './components/dashboard/orders/orders.component';
import { ContactsComponent } from './components/dashboard/contacts/contacts.component';
import { LeadsComponent } from './components/dashboard/leads/leads.component';
import { TasksComponent } from './components/dashboard/tasks/tasks.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import { DashboardMainComponent } from './components/dashboard/dashboard-main/dashboard-main.component';
import { UserDetailFormComponent } from './components/dashboard/users/user-detail-form/user-detail-form.component';


@NgModule({
  declarations: [
    AppComponent,
    ...fromMain.components,
    ...fromPages.components,
    ...fromDashboardJobs.components,
    ...fromAccount.components,
    ...fromDashboardCustomers.components,
    ...fromDashboardUsers.components,
    DashboardComponent,
    CampaignsComponent,
    NotesComponent,
    ProductsComponent,
    OrdersComponent,
    ContactsComponent,
    LeadsComponent,
    TasksComponent,
    DashboardMainComponent,
    UserDetailFormComponent,
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
