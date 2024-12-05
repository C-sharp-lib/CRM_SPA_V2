import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from '../services';

@Injectable({
  providedIn: 'root'
})
export class AccountGuard implements CanActivate {
  constructor(private authService: AccountService, private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    if (this.authService.isAuthenticated()) {
      return true;
    } else {
      // Redirect the user to login page if not authenticated
      this.router.navigate(['/login-page']);
      return false;
    }
  }
}
