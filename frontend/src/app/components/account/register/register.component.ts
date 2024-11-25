import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AccountService} from '../../../services';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm: FormGroup;
  errorMessage: string = '';
  isPasswordVisiblePassword: boolean = false;
  isPasswordVisibleConfirmPassword: boolean = false;
  constructor(private fb: FormBuilder, private authService: AccountService) {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      dob: ['', Validators.required],
      userName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      isActive: ['', Validators.required],
      hireDate: ['', Validators.required],
      passwordHash: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    });
  }

  onRegister() {
    if (this.registerForm.valid) {
      this.authService.register(this.registerForm.value).subscribe({
        next: (response) => {
          alert('Registration successful!');
          window.location.href = '/login';
        },
        error: (err) => {
          this.errorMessage = err.error?.message || 'Registration failed. Please try again.';
        }
      });
    }
  }

  togglePasswordVisibilityPassword(): void {
    this.isPasswordVisiblePassword = !this.isPasswordVisiblePassword;
  }
  togglePasswordVisibilityConfirmPassword(): void {
    this.isPasswordVisibleConfirmPassword = !this.isPasswordVisibleConfirmPassword;
  }
}
