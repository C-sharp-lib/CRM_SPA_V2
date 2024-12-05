import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {AccountService} from '../../../../services';
import {User} from '../../../../models/user';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit {
  users: User[] = [];
  errorMessage: string = '';
constructor(private router: Router, private authService: AccountService, private route: ActivatedRoute) {
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
}
