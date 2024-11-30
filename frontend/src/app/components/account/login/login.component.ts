import { Component } from '@angular/core';
import {AccountService} from '../../../services';
import {Router} from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  email: string = '';
  password: string = '';
  rememberMe: boolean = false;
  errorMessage: string = '';
  isPasswordVisible: boolean = false;

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      rememberMe: ['', Validators.required],
    });
  }

  login(): void {
    this.accountService.login({ email: this.email, password: this.password }).subscribe(
      response => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/dashboard/dashboard-main']);
      },
      error => {
        this.errorMessage = 'Login failed. Please check your credentials.';
      }
    );
  }

  togglePasswordVisibility(): void {
    this.isPasswordVisible = !this.isPasswordVisible;
  }
}
