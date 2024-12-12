import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {AccountService} from '../../../../services';
import {CustomerUsers, User} from '../../../../models/user';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css'
})
export class UserDetailComponent implements OnInit {
  user: User;
  errorMessage: string = '';
  constructor(private route: ActivatedRoute, private authService: AccountService) {
  }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.showUser(id);
    });
  }

  showUser(id: string) {
    this.authService.getUserById(id).subscribe(
      (data) => {
        this.user = data;
        this.user.campaignUserTasks = data.campaignUserTasks;
        this.user.jobUserTasks = data.jobUserTasks;
    }, (error) => {
      this.errorMessage = "Could not fetch the user with the id: " + id;
      console.error(error);
    })
  }

}
