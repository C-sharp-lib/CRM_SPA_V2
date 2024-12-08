import {OrderItems} from './order-items';

export interface Product {
  productId: number;
  name: string;
  description: string;
  category: string;
  price: number;
  upc: string;
  currency: string;
  quantityInStock: number;
  isActive: boolean;
  imageUrl: string;
  createdAt?: Date;
  updatedAt?: Date;
  orderItems: OrderItems;
}
