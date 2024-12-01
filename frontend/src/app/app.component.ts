import { Component } from '@angular/core';
import {Router} from '@angular/router';
import {AccountService} from './services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
  constructor(private router: Router, private authService: AccountService) {
  }

  get isUserAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }
}
