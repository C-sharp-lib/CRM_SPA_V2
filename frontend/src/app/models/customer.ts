import {CustomerType} from './customer-type';
import {CustomerStatus} from './customer-status';
import {CustomerOrders} from './orders';

export interface Customer {
  customerId: number | undefined;
  customerType: CustomerType;
  name: string;
  email: string;
  phone: string;
  fax: string;
  status: CustomerStatus;
  address: string;
  city: string;
  state: string;
  zipCode: string;
  industry: string;
  website: string;
  contactPerson: string;
  notes: string;
  customerOrders: CustomerOrders[];
}
