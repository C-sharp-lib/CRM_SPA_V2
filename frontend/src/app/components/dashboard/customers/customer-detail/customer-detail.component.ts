import {Component, OnInit} from '@angular/core';
import {CustomerService} from '../../../../services';
import {ActivatedRoute} from '@angular/router';
import {Customer} from '../../../../models/customer';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrl: './customer-detail.component.css'
})
export class CustomerDetailComponent implements OnInit {
  customer: Customer;
  constructor(private route: ActivatedRoute, private customerService: CustomerService) {}
  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.showCustomer(id);
    });
  }

  showCustomer(id: number) {
    this.customerService.getCustomer(id).subscribe(
      (data) => {
        this.customer = data;
      }, (error) => {
        console.log(error);
      }
    );
  }
}
