import {Component, OnInit} from '@angular/core';
import {AccountService} from '../../../services';
import {User} from '../../../models/user';
import {ActivatedRoute, NavigationEnd, Router} from '@angular/router';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent implements OnInit {
  user: User;
  showMenu: boolean = false;
  constructor(private authService: AccountService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        const childRoute = this.route.firstChild;
        if (childRoute && childRoute.snapshot.data['showMenu'] !== undefined) {
          this.showMenu = childRoute.snapshot.data['showMenu'];
        } else {
          this.showMenu = false;
        }
      }
    });
  }

  showUserCreate(): boolean {
    if(this.router.url === '/dashboard/users/user-create') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
  showUserList(): boolean {
    if(this.router.url === '/dashboard/users/user-list') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }

}
