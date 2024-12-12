import { Component } from '@angular/core';
import {Job} from '../../../../models/job';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {JobService} from '../../../../services';
import {JobStatus} from '../../../../models/job-status';
import {JobPriority} from '../../../../models/job-priority';

@Component({
  selector: 'app-job-create',
  templateUrl: './job-create.component.html',
  styleUrl: './job-create.component.css'
})
export class JobCreateComponent {
  jobForm: FormGroup;
  jobStatus = Object.values(JobStatus);
  jobPriority = Object.values(JobPriority);
  constructor(private fb: FormBuilder, private jobService: JobService) {
    this.jobForm = this.fb.group({
      jobTitle: ['', Validators.required],
      jobDescription: ['', Validators.required],
      jobStatus: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      priority: ['', Validators.required],
      estimatedCost: ['', [Validators.required, Validators.pattern('^[0-9]*\\.?[0-9]{0,2}$')]],
      actualCost: ['', [Validators.required, Validators.pattern('^[0-9]*\\.?[0-9]{0,2}$')]]
    });
  }

  onSubmit(): void {
    if(!this.jobForm.invalid) {
      const newJob: Job = {
        customerJobs: [],
        jobUserNotes: [],
        jobUserTasks: [],
        jobTitle: this.jobForm.value.jobTitle,
        jobDescription: this.jobForm.value.jobDescription,
        jobStatus: this.jobForm.value.jobStatus,
        startDate: new Date(this.jobForm.value.startDate),
        endDate: new Date(this.jobForm.value.endDate),
        priority: this.jobForm.value.priority,
        estimatedCost: this.jobForm.value.estimatedCost,
        actualCost: this.jobForm.value.actualCost,
        jobId: undefined
      };
      this.jobService.createJob(newJob).subscribe(
        (response) => {
          console.log('Job added successfully', response);
          // Optionally, reset the form or show success feedback
          this.jobForm.reset();
        },
        (error) => {
          console.error('Error adding job', error);
        }
      );
    }
  }
}
