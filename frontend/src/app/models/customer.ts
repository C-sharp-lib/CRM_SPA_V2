import {CustomerType} from './customer-type';
import {CustomerStatus} from './customer-status';

export class Customer {
  customerId: number | undefined;
  customerType: CustomerType | undefined;
  name: string = '';
  email: string = '';
  phone: string = '';
  fax: string = '';
  status: CustomerStatus | undefined;
  address: string = '';
  city: string = '';
  state: string = '';
  zipCode: string = '';
  industry: string = '';
  website: string = '';
  contactPerson: string = '';
  notes: string = '';

  constructor(init?: Partial<Customer>) {
    Object.assign(this, init);
  }
}
