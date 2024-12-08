import {Component} from '@angular/core';
import {CustomerService} from '../../../../services/customer.service';

@Component({
  selector: 'app-customer-search',
  templateUrl: './customer-search.component.html',
  styleUrl: './customer-search.component.css'
})
export class CustomerSearchComponent {
  searchedQuery: string = '';
  results: any[] = [];

  constructor(private customerService: CustomerService) {
  }

  onSearch() {
    if(this.searchedQuery.trim() === '') return;
    this.customerService.searchCustomers(this.searchedQuery).subscribe({
      next: (data) => (this.results = data),
      error: (err) => console.error(err),
    });
  }


}
