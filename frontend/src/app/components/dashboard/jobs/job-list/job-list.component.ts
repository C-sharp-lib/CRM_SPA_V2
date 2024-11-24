import {Component, OnInit} from '@angular/core';
import {JobService} from '../../../../services';
import {Job} from '../../../../models/job';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrl: './job-list.component.css'
})
export class JobListComponent implements OnInit {
  jobs: Job[] = [];
  constructor(private jobService: JobService) {}
  ngOnInit() {
    this.loadJobs();
  }
  loadJobs(): void {
    this.jobService.getJobs().subscribe(
      (response) => {
        this.jobs = response;
      },
      (error) => {
        console.error('Error fetching jobs:', error);
      }
    );
  }
}
