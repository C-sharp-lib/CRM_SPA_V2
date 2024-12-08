import {Component, OnInit} from '@angular/core';
import {AccountService, CustomerService, JobService, ProductService} from '../../../services';
import {Router} from '@angular/router';
import {Product} from '../../../models/product';
import {User} from '../../../models/user';

@Component({
  selector: 'app-dashboard-main',
  templateUrl: './dashboard-main.component.html',
  styleUrl: './dashboard-main.component.css'
})
export class DashboardMainComponent implements OnInit {
  products: number;
  customers: number;
  jobs: number;
  users: number;
  constructor(private productService: ProductService,
              private customerService: CustomerService,
              private jobService: JobService,
              private accountService: AccountService,
              private router: Router) {}

  ngOnInit() {
    this.getProductCount();
    this.getCustomerCount();
    this.getJobCount();
    this.getUserCount();
  }

  getProductCount() {
    this.productService.productCount().subscribe(
      (count) => {
        this.products = count;
      },
      (error) => {
        this.products = 0;
        console.log(error);
      }
    );
  }
  getCustomerCount() {
    this.customerService.customerCount().subscribe(
      (count) => {
        this.customers = count;
      },
      (error) => {
        this.customers = 0;
        console.log(error);
      }
    );
  }
  getJobCount() {
    this.jobService.jobCount().subscribe(
      (count) => {
        this.jobs = count;
      },
      (error) => {
        this.jobs = 0;
        console.log(error);
      }
    );
  }
  getUserCount() {
    this.accountService.userCount().subscribe(
      (count) => {
        this.users = count;
      },
      (error) => {
        this.users = 0;
        console.log(error);
      }
    );
  }
}
