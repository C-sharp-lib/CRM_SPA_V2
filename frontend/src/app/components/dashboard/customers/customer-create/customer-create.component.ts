import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {CustomerService} from '../../../../services/customer.service';
import {Customer} from '../../../../models/customer';
import {CustomerType} from '../../../../models/customer-type';
import {CustomerStatus} from '../../../../models/customer-status';

@Component({
  selector: 'app-customer-create',
  templateUrl: './customer-create.component.html',
  styleUrl: './customer-create.component.css'
})
export class CustomerCreateComponent {
  customerForm: FormGroup;
  customerTypes = Object.values(CustomerType);
  customerStatus = Object.values(CustomerStatus);
  constructor(
    private fb: FormBuilder,
    private customerService: CustomerService
  ) {
    this.customerForm = this.fb.group({
      customerType: ['', Validators.required],
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
      fax: ['', Validators.required],
      status: ['', Validators.required],
      address: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      zipCode: ['', Validators.required],
      industry: ['', Validators.required],
      website: ['', Validators.required],
      contactPerson: ['', Validators.required],
      notes: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.customerForm.valid) {
      const newCustomer = this.customerForm.value;
      this.customerService.createCustomer(newCustomer).subscribe(
        (response) => {
          console.log('Customer added successfully', response);
          this.customerForm.reset();
        },
        (error) => {
          console.error('Error adding customer', error);
        }
      );
    }
  }
}
