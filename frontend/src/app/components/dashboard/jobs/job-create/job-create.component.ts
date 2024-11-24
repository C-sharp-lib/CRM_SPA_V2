import { Component } from '@angular/core';
import {Job} from '../../../../models/job';
import {HttpClient} from '@angular/common/http';
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
  constructor(private fb: FormBuilder, private jobService: JobService, private http: HttpClient) {
    this.jobForm = this.fb.group({
      customerId: ['', Validators.required],
      jobTitle: ['', Validators.required],
      jobDescription: ['', Validators.required],
      jobStatus: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      assignedTo: ['', Validators.required],
      priority: ['', Validators.required],
      estimatedCost: ['', [Validators.required, Validators.pattern('^[0-9]*\\.?[0-9]{0,2}$')]],
      actualCost: ['', [Validators.required, Validators.pattern('^[0-9]*\\.?[0-9]{0,2}$')]],
      createdBy: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if(this.jobForm.invalid) {
      const newJob: Job = {
        customerId: this.jobForm.value.customerId,
        jobTitle: this.jobForm.value.jobTitle,
        jobDescription: this.jobForm.value.jobDescription,
        jobStatus: this.jobForm.value.jobStatus,
        startDate: new Date(this.jobForm.value.startDate),
        endDate: new Date(this.jobForm.value.endDate),
        assignedTo: this.jobForm.value.assignedTo,
        priority: this.jobForm.value.priority,
        estimatedCost: this.jobForm.value.estimatedCost,
        actualCost: this.jobForm.value.actualCost,
        createdAt: new Date(), // Use current date
        createdBy: this.jobForm.value.createdBy,
        lastUpdatedBy: this.jobForm.value.createdBy,
        lastUpdatedDate: new Date(),
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
