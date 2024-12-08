import {OrderItems} from './order-items';
import {Customer} from './customer';

export interface Orders {
  orderId: number;
  orderDate: Date;
  totalAmount: number;
  discountAmount: number;
  netAmount: number;
  paymentStatus: string;
  paymentMethod: string;
  shippingAddress: string;
  billingAddress: string;
  notes: string;
  createdAt: Date;
  updatedAt: Date;
  orderItems: OrderItems;
  customerOrders: CustomerOrders;
}

export interface CustomerOrders {
  customerOrderId: number;
  customerId: Customer;
  orderId: Orders;
}
