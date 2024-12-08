import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Product} from '../models/product';
import {Observable} from 'rxjs';
import {retry} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl: string = environment.apiUrl + "/Product";
  constructor(private http: HttpClient) { }

  createProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.baseUrl}/create-product`, product);
  }
  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl);
  }
  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.baseUrl}/product-details/${id}`);
  }
  updateProduct(product: Product): Observable<Product> {
    if(!product.productId) {
      throw new Error('Product Id is required for update.');
    }
    const url = `${this.baseUrl}/update-product/${product.productId}`;
    return this.http.put<Product>(url, product).pipe(
      retry(1)
    );
  }
  deleteProduct(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
  productCount() {
    return this.http.get<number>(`${this.baseUrl}/product-count`);
  }
}
