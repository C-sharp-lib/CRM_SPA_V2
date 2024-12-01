import {Component, OnInit} from '@angular/core';
import {AccountService} from '../../../services';
import {User} from '../../../models/user';
import {Router} from '@angular/router';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent implements OnInit {
  users: any;
  user: any;
  errorMessage: string = '';
  constructor(private authService: AccountService, private router: Router) {
  }

  ngOnInit(): void {
    this.showUserData();
  }

  showUserData() {
    return this.authService.getUsers().subscribe(
      (data) => {
        this.users = data;
      },
      (error) => {
        this.errorMessage = error.error?.message;
        console.error('There was an error retrieving the user data: ' + error);
      }
    );
  }
  showUser(id: string) {
    this.authService.getUserById(id).subscribe(
      (data) => {
        this.user = data;
      },
      (error) => {
        this.errorMessage = error.error?.message;
        console.error('There was an error retrieving the user data: ' + error);
      }
    )
  }
}
