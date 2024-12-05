import { Component } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {AccountService} from '../../../../services';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-user-detail-form',
  templateUrl: './user-detail-form.component.html',
  styleUrl: './user-detail-form.component.css'
})
export class UserDetailFormComponent {
  user: any;
  userDetailForm: FormGroup;
  errorMessage: string = '';
  isPasswordVisiblePassword: boolean = false;
  isPasswordVisibleConfirmPassword: boolean = false;
  constructor(private fb: FormBuilder, private authService: AccountService) {
    this.userDetailForm = this.fb.group({
      id: [{ value: '', disabled: true }, Validators.required],
      imageUrl: [''],
      userName: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber: [''],
      firstName: [''],
      lastName: [''],
      dob: [''],
      isActive: [false],
      hireDate: [''],
    }, { validators: this.passwordMatchValidator });
  }
  ngOnInit(): void {
    if (this.user){
      this.userDetailForm.patchValue(this.user);
    }
    this.authService.getUserById(this.user.id).subscribe((data) => {
      this.userDetailForm.patchValue({
        userName: data.userName,
        email: data.email,
        password: data.password,
        confirmPassword: data.confirmPassword,
        phoneNumber: data.phoneNumber,
        firstName: data.firstName,
        middleName: data.firstName,
        lastName: data.lastName,
        dob: data.dob,
        hireDate: data.hireDate,
        isActive: data.isActive,
        imageUrl: data.imageUrl
      });
    });
  }

  passwordMatchValidator(group: FormGroup): { [key: string]: boolean } | null {
    const password = group.get('password')?.value;
    const confirmPassword = group.get('confirmPassword')?.value;
    return password === confirmPassword ? null : { passwordsDoNotMatch: true };
  }
  onSubmit(): void {
    if (this.userDetailForm.valid) {
      const updatedUser = { ...this.user, ...this.userDetailForm.getRawValue() };
      console.log('Updated User:', updatedUser);
    }
  }
  togglePasswordVisibilityPassword(): void {
    this.isPasswordVisiblePassword = !this.isPasswordVisiblePassword;
  }

  togglePasswordVisibilityConfirmPassword(): void {
    this.isPasswordVisibleConfirmPassword = !this.isPasswordVisibleConfirmPassword;
  }

}
