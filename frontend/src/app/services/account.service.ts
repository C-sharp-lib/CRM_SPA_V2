import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Router} from '@angular/router';
import {environment} from '../../environments/environment';
import {jwtDecode} from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private baseUrl = environment.apiUrl + "/Account";
  constructor(private http: HttpClient, private router: Router) { }
  register(user: {email: string, userName: string, password: string, confirmPassword: string}): Observable<any> {
    return this.http.post(`${this.baseUrl}/register`, user);
  }
  login(credentials: { email: string; password: string, rememberMe: boolean }): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/login`, credentials);
  }

  logout() {
    this.clearToken();
    this.router.navigate(['/login-page']);
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return token != null;
  }

  saveToken(token: string): void {
    localStorage.setItem('token', token);
  }

  // Remove the token (e.g., after logout)
  clearToken(): void {
    localStorage.removeItem('token');
  }

  // Retrieve the token
  getToken(): string | null {
    return localStorage.getItem('token');
  }
  getDecodedToken(): any {
    const token = this.getToken();
    if(!token) {
      return null;
    }
    return jwtDecode(token);
  }
  getUserData(): Observable<any> {
    return this.http.get(`${this.baseUrl}/userData`);
  }
  getUsers(): Observable<any> {
    return this.http.get(`${this.baseUrl}/users`);
  }
  getUserById(id: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/users/${id}`);
  }
}
