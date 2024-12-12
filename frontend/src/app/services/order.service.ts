import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {retry} from 'rxjs/operators';
import {Orders} from '../models/orders';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl: string = environment.apiUrl + "/Orders";
  constructor(private http: HttpClient) { }

  createOrder(order: Orders): Observable<Orders> {
    return this.http.post<Orders>(`${this.baseUrl}/create-order`, order);
  }
  getOrders(): Observable<Orders[]> {
    return this.http.get<Orders[]>(this.baseUrl);
  }
  getOrder(id: number): Observable<Orders> {
    return this.http.get<Orders>(`${this.baseUrl}/order-details/${id}`);
  }
  updateOrder(id: number, order: Orders): Observable<Orders> {
    if(!order.orderId) {
      throw new Error('Order Id is required for update.');
    }
    const url = `${this.baseUrl}/update-order/${order.orderId}`;
    return this.http.put<Orders>(url, order).pipe(
      retry(1)
    );
  }
  deleteOrder(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
  OrderCount() {
    return this.http.get<number>(`${this.baseUrl}/order-count`);
  }
}
