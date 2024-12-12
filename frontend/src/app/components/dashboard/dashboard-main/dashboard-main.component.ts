import {Component, OnInit} from '@angular/core';
import {AccountService, CustomerService, JobService, ProductService} from '../../../services';
import {ActivatedRoute, NavigationEnd, Router} from '@angular/router';


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
  showMenu: boolean = false;
  constructor(private productService: ProductService,
              private customerService: CustomerService,
              private jobService: JobService,
              private accountService: AccountService,
              private router: Router,
              private route: ActivatedRoute) {}

  ngOnInit() {
    this.getProductCount();
    this.getCustomerCount();
    this.getJobCount();
    this.getUserCount();
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        const childRoute = this.route.firstChild;
        if (childRoute && childRoute.snapshot.data['showMenu'] !== undefined) {
          this.showMenu = childRoute.snapshot.data['showMenu'];
        } else {
          this.showMenu = false;
        }
      }
    });
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
  showJobList(): boolean {
    if(this.router.url === '/dashboard/dashboard-main/job-list') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }

  showCustomerList(): boolean {
    if(this.router.url === '/dashboard/dashboard-main/customer-list') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
  showUserList(): boolean {
    if(this.router.url === '/dashboard/dashboard-main/user-list') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
  showProductList(): boolean {
    if(this.router.url === '/dashboard/dashboard-main/product-list') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
}
