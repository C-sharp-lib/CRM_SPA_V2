import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient, HttpParams} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Customer} from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  baseUrl: string = environment.apiUrl + "/Customer";

  constructor(private http: HttpClient) { }
  createCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.baseUrl, customer);
  }
  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.baseUrl);
  }
  getCustomer(id: number): Observable<Customer> {
    return this.http.get<Customer>(`${this.baseUrl}/${id}`);
  }
  updateCustomer(id: number, customer: Customer): Observable<Customer> {
    return this.http.put<Customer>(`${this.baseUrl}/${id}`, customer);
  }
  deleteCustomer(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
  searchCustomers(keyword: string): Observable<any> {
    const params = new HttpParams().set('keyword', keyword);
    return this.http.get(`${this.baseUrl}/search`, {params});
  }
}
