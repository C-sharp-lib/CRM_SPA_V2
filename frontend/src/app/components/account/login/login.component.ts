import {Component, Inject} from '@angular/core';
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
  isSubmitting: boolean = false;
  email: string = '';
  password: string = '';
  rememberMe: boolean = true;
  errorMessage: string = '';
  successMessage: string = '';
  isPasswordVisiblePassword: boolean = false;

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      rememberMe: [true],
    });

  }

  login(): void {
    if(!this.loginForm.invalid) {
      this.isSubmitting = true;
      const credentials = this.loginForm.value;
      this.accountService.login(credentials).subscribe(
        response => {
          localStorage.setItem('token', response.token);
          this.successMessage = 'User logged in successfully.';
          this.loginForm.reset();
          this.router.navigate(['/dashboard/dashboard-main']).then(() => {
            window.location.reload();
          });
          this.isSubmitting = false;
        },
        error => {
          this.errorMessage = 'Login failed. Please check your credentials.';
          this.isSubmitting = false;
        }
      );
    }
  }

  togglePasswordVisibilityPassword(): void {
    this.isPasswordVisiblePassword = !this.isPasswordVisiblePassword;
  }
}
