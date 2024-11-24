import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, NavigationEnd, Router} from '@angular/router';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent implements OnInit {
  showMenu: boolean = false;
  constructor(private router: Router, private route: ActivatedRoute) {
  }
  ngOnInit(): void {
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


  showCustomerList(): boolean {
    if(this.router.url === '/dashboard/customers/customer-list') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }

  showCustomerCreate(): boolean {
    if(this.router.url === '/dashboard/customers/customer-create') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
}
