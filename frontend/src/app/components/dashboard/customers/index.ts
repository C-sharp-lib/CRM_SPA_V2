import {CustomersComponent} from './customers.component';
import {CustomerListComponent} from './customer-list/customer-list.component';
import {CustomerSearchComponent} from './customer-search/customer-search.component';
import {CustomerCreateComponent} from './customer-create/customer-create.component';
import {CustomerDetailComponent} from './customer-detail/customer-detail.component';


export const components: any[] = [
  CustomersComponent,
  CustomerCreateComponent,
  CustomerDetailComponent,
  CustomerSearchComponent,
  CustomerListComponent
];

export * from './customers.component';
export * from './customer-list/customer-list.component';
export * from './customer-search/customer-search.component';
export * from './customer-create/customer-create.component';
export * from './customer-detail/customer-detail.component';
