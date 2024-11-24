import {Component, OnInit} from '@angular/core';
import {Customer} from '../../../../models/customer';
import {CustomerService} from '../../../../services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css'
})
export class CustomerListComponent implements OnInit {
  customers: Customer[] = [];
  constructor(private customerService: CustomerService) {}

  ngOnInit() {
    this.loadCustomers();
  }

  loadCustomers(): void {
    this.customerService.getCustomers().subscribe(
      (response) => {
        this.customers = response;
      },
      (error) => {
        console.error('Error fetching customers', error);
      }
    )
  }
}
