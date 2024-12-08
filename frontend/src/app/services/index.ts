import {AccountService} from './account.service';
import {JobService} from './job.service';
import {CustomerService} from './customer.service';
import {ModalService} from './modal.service';
import {WindowService} from './window.service';
import {ProductService} from './product.service';

export const services: any[] = [
  AccountService,
  JobService,
  CustomerService,
  ProductService,
  ModalService,
  WindowService
];


export * from './account.service';
export * from './job.service';
export * from './customer.service';
export * from './modal.service';
export * from './window.service';
export * from './product.service';
