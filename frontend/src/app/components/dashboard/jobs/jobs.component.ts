import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, NavigationEnd, Router} from '@angular/router';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrl: './jobs.component.css'
})
export class JobsComponent implements OnInit {
  showMenu: boolean = false;
  constructor(private router: Router, private route: ActivatedRoute) {
  }
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

  showJobCalendar(): boolean {
    if(this.router.url === '/dashboard/jobs/job-calendar') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }

  showJobList(): boolean {
    if(this.router.url === '/dashboard/jobs/job-list') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }

  showJobCreate(): boolean {
    if(this.router.url === '/dashboard/jobs/job-create') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }

  showJobSearch(): boolean {
    if(this.router.url === '/dashboard/jobs/job-search') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
}
