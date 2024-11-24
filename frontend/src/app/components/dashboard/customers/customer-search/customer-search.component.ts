import {Component} from '@angular/core';
import {CustomerService} from '../../../../services/customer.service';

@Component({
  selector: 'app-customer-search',
  templateUrl: './customer-search.component.html',
  styleUrl: './customer-search.component.css'
})
export class CustomerSearchComponent {
  keyword: string = '';
  results: any[] = [];
  errorMessage: string = '';

  constructor(private customerService: CustomerService) {
  }

  onSearch() {
    this.errorMessage = '';
    if (!this.keyword.trim()) {
      this.errorMessage = 'Please enter a keyword to search.';
      return;
    }
    this.customerService.searchCustomers(this.keyword).subscribe(
      (data) => {
        this.results = data;
      },
      (error) => {
        this.errorMessage = error.error?.Message || 'An error occurred when fetching customers.  Please try again.';
        this.results = [];
      }
    );
  }


}
