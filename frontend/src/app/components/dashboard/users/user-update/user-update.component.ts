import {Component, Input, OnInit} from '@angular/core';
import {User} from '../../../../models/user';
import {AccountService} from '../../../../services';
import {ActivatedRoute, Router} from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';


@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrl: './user-update.component.css'
})
export class UserUpdateComponent implements OnInit {
  @Input() user: User;
  userId: string;
  userDetailForm: FormGroup;
  isChecked: boolean = false;
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private authService: AccountService, private route: ActivatedRoute) {
    this.userDetailForm = this.fb.group({
      id: [{ value: '', disabled: true }],
      imageUrl: [''],
      userName: [''],
      email: [''],
      firstName: [''],
      middleName: [''],
      lastName: [''],
      dob: [''],
      isActive: [false],
      hireDate: [''],
    });
  }
    ngOnInit(): void {
      this.userId = this.route.snapshot.paramMap.get('id') || '';
      this.route.params.subscribe(params => {
        const id = params['id'];
        this.showUserUpdate(id);
      });
      if (this.user){
      this.userDetailForm.patchValue({
        id: this.user.id,
        firstName: this.user.firstName,
        middleName: this.user.middleName,
        lastName: this.user.lastName,
        email: this.user.email,
        userName: this.user.userName,
        dob: this.user.dob,
        hireDate: this.user.hireDate,
        isActive: this.user.isActive,
        imageUrl: this.user.imageUrl,
      });
    }
  }

  showUserUpdate(id: string) {
    this.authService.getUserById(id).subscribe(data => {
      this.user = data;
    }, error => {
      console.error(error);
    })
  }

  onSubmit(): void {
    if(this.userDetailForm.valid){
      this.authService.updateUser(this.userId, this.userDetailForm.value).subscribe(
        () => {
          console.log('user updated successfully');
        }, (error) => {
          console.error(error);
        }
      );
    }
  }

}
