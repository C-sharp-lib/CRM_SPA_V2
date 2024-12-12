import {Orders, OrdersOrderItems} from './orders';
import {Product} from './product';

export interface OrderItems {
  orderItemId: number;
  orderId: number;
  productId: number;
  quantity: number;
  unitPrice: number;
  totalPrice: number;
  products: Product;
  ordersOrderItems: OrdersOrderItems[];
}
