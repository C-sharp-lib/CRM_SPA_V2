import {AccountService} from './account.service';
import {JobService} from './job.service';
import {CustomerService} from './customer.service';
import {ModalService} from './modal.service';
import {WindowService} from './window.service';
import {ProductService} from './product.service';
import {CampaignService} from './campaign.service';
import {OrderService} from './order.service';

export const services: any[] = [
  AccountService,
  JobService,
  CustomerService,
  ProductService,
  ModalService,
  WindowService,
  CampaignService,
  OrderService,
];


export * from './account.service';
export * from './job.service';
export * from './customer.service';
export * from './modal.service';
export * from './window.service';
export * from './product.service';
export * from './campaign.service';
export * from './order.service';
