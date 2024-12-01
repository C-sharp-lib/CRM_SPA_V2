import {Component, HostListener, Injectable, OnInit, PLATFORM_ID} from '@angular/core';
import {ActivatedRoute, Router, NavigationEnd} from '@angular/router';
import {WindowService} from '../../../services/window.service';
import {AccountService} from '../../../services';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {
  showMenu: boolean = false;
  userData: any;
  errorMessage: string = '';

  constructor(private router: Router, private route: ActivatedRoute, private authService: AccountService) {}
  ngOnInit(): void {
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
  //
  // toggleMobileMenu(): void {
  //   this.checkMobileWidth();
  // }
  // checkMobileWidth(): void {
  //   if(this.windowService) {
  //     this.isMobileMenuOpen = !this.isMobileMenuOpen;
  //   } else {
  //     this.isMobileMenuOpen = false;
  //   }
  // }
  // closeMobileMenu(): void {
  //   this.isMobileMenuOpen = false;
  // }
  showJobsMenu(): boolean {
    if(this.router.url === '/dashboard/jobs' ||
      this.router.url === '/dashboard/jobs/job-calendar' ||
      this.router.url === '/dashboard/jobs/job-list' ||
      this.router.url === '/dashboard/jobs/job-create' ||
      this.router.url === '/dashboard/jobs/job-search') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
  showCustomersMenu(): boolean {
    if(this.router.url === '/dashboard/customers' ||
      this.router.url === '/dashboard/customers/customer-list' ||
      this.router.url === '/dashboard/customers/customer-create' ||
      this.router.url === '/dashboard/customers/customer-search') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
  showCampaignsMenu(): boolean {
    if(this.router.url === '/dashboard/campaigns') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }

  showContactsMenu(): boolean {
    if (this.router.url == '/dasboard/contacts') {
      return this.showMenu = true;
    } else if (this.router.url === '/dasboard/contacts/contact-list') {
      return this.showMenu = true;
    } else if (this.router.url === '/dasboard/contacts/contact-search') {
      return this.showMenu = true;
    } else if (this.router.url === '/dasboard/contacts/contact-create') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
  authenticated() {
    const token = localStorage.getItem('token');
    return token != null;
  }
  logout() {
    this.authService.logout();
    this.router.navigate(['/login-page']);
  }
}

