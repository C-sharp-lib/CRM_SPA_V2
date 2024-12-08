import {Orders} from './orders';
import {Product} from './product';

export interface OrderItems {
  orderItemId: number;
  orderId: Orders;
  productId: Product;
  quantity: number;
  unitPrice: number;
  totalPrice: number;
}
