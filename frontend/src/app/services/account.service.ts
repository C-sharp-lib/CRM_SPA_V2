import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {response} from 'express';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private apiUrl: string = "http://localhost:5130/api/Account";
  constructor(private http: HttpClient) { }
  // login(email: string, password: string, rememberMe: boolean) : Observable<boolean> {
  //   const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  //   const body = {email, password, rememberMe};
  //   return this.http.post<{token: string}>(`${this.apiUrl}/login`, body, {headers})
  //     .pipe(
  //       map(response => {
  //         if(response && response.token) {
  //           localStorage.setItem('authToken', response.token);
  //           return true;
  //         }
  //         return false;
  //       })
  //     );
  // }
  // logout(): void {
  //   localStorage.removeItem('authToken');
  // }
  // isAuthenticated(): boolean {
  //   return localStorage.getItem('authToken') !== null;
  // }
}
