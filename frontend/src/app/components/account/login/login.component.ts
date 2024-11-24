import { Component } from '@angular/core';
import {AccountService} from '../../../services';
import {Router} from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  rememberMe: boolean = false;
  errorMessage: string = '';

  constructor(private aService: AccountService, private router: Router) {
  }

  // onLogin(): void {
  //   this.aService.login(this.email, this.password, this.rememberMe).subscribe({
  //     next: (isAuthenticated) => {
  //      if(isAuthenticated) {
  //        this.router.navigate(['/dashboard']);
  //      } else {
  //        this.errorMessage = 'Invalid email or password';
  //      }
  //     },
  //     error: () => {
  //       this.errorMessage = 'Unable to login. Please try again later.';
  //     }
  //   })
  // }
}
