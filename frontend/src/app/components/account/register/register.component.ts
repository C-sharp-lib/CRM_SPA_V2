import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AccountService} from '../../../services';
import {User} from '../../../models/user';
import {Router} from '@angular/router';
import {Job} from '../../../models/job';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm: FormGroup;
  errorMessage: string = '';
  successMessage: string = '';
  isPasswordVisiblePassword: boolean = false;
  isPasswordVisibleConfirmPassword: boolean = false;

  constructor(private authService: AccountService, private fb: FormBuilder, private router: Router) {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      userName: ['', [Validators.required, Validators.minLength(5)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
    })
  }

  onSubmit(): void {
    if(!this.registerForm.invalid) {
      const newUser: { password: any; confirmPassword: any; id: undefined; userName: any; email: any } = {
        id: undefined,
        userName: this.registerForm.value.userName,
        email: this.registerForm.value.email,
        password: this.registerForm.value.password,
        confirmPassword: this.registerForm.value.confirmPassword
      };
      this.authService.register(newUser).subscribe(
        (response) => {
          console.log('User registered successfully', response);
          this.registerForm.reset();
          this.router.navigate(['login-page']);
        },
        (error) => {
          console.error('Error adding user', error);
        }
      );
    }
  }

  togglePasswordVisibilityPassword(): void {
    this.isPasswordVisiblePassword = !this.isPasswordVisiblePassword;
  }

  togglePasswordVisibilityConfirmPassword(): void {
    this.isPasswordVisibleConfirmPassword = !this.isPasswordVisibleConfirmPassword;
  }
}
