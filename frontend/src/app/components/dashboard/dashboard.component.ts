import { Component } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  constructor(private router: Router, private route: ActivatedRoute) {
  }

  showCampaigns(): boolean {
    return this.router.url === 'campaigns'
  }
  showContacts(): boolean {
    return this.router.url === 'contacts';
  }
  showCustomers(): boolean {
    return this.router.url === 'customers';
  }
  showJobs(): boolean {
    return this.router.url === 'jobs';
  }
  showLeads(): boolean {
    return this.router.url === 'leads';
  }
  showNotes(): boolean {
    return this.router.url === 'notes';
  }
  showOrders(): boolean {
    return this.router.url === 'orders';
  }
  showProducts(): boolean {
    return this.router.url === 'products';
  }
  showTasks(): boolean {
    return this.router.url === 'tasks';
  }
  showUsers(): boolean {
    return this.router.url === 'users';
  }
  showDashboardMain(): boolean {
    return this.router.url === 'dashboard/dashboard-main';
  }
}
