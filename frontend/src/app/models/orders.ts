import {Customer} from './customer';
import {OrderItems} from './order-items';

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
  ordersOrderItems: OrdersOrderItems[];
  customerOrders: CustomerOrders[];
}

export interface CustomerOrders {
  customerOrderId: number;
  customerId: Customer;
  orderId: Orders;
}
export interface OrdersOrderItems {
  orderId: number;
  orderItemId: number;
  ordersOrderItemsId: number;
  order: Orders;
  orderItem: OrderItems;
}
