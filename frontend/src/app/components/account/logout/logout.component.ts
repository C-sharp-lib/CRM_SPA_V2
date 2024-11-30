import { Component } from '@angular/core';
import {AccountService} from '../../../services';
import {Router} from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent {
  constructor(private accountService: AccountService, private router: Router) {
  }
  logout(): void {
    this.accountService.logout();
    this.router.navigate(['/']);
  }
}
