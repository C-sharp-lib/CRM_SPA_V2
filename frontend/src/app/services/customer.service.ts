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
  customerCount() {
    return this.http.get<number>(`${this.baseUrl}/customer-count`);
  }
  searchCustomers(name?: string, email?: string, industry?: string): Observable<any> {
    let params: any = {};
    if (name) params.name = name;
    if (email) params.email = email;
    if (industry) params.industry = industry;
    return this.http.get<any[]>(`${this.baseUrl}/search-customers`, {params});
  }
}
