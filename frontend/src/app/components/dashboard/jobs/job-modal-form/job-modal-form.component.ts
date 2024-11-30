import {Component, Input} from '@angular/core';
import {JobStatus} from '../../../../models/job-status';
import {JobPriority} from '../../../../models/job-priority';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-job-modal-form',
  templateUrl: './job-modal-form.component.html',
  styleUrl: './job-modal-form.component.css'
})
export class JobModalFormComponent {
  jobStatus = Object.values(JobStatus);
  jobPriority = Object.values(JobPriority);
  @Input() startDate: string;
  @Input() endDate: string;
  @Input() jobTitle: string;
  @Input() status: JobStatus;
  @Input() priority: JobPriority;
  @Input() jobDescription: string;
  @Input() estimatedCost: number;
  @Input() actualCost: number;
  job = {
    jobTitle: 'New Job',
    jobDescription: '',
    startDate: new Date(),
    endDate: new Date(),
    actualCost: 0.0,
    estimatedCost: 0.0,
    jobId: undefined,
    jobStatus: JobStatus.Created,
    priority: JobPriority.Low
  };


  constructor(public activeModal: NgbActiveModal) {}

  save() {
    this.activeModal.close({
      jobTitle: this.jobTitle,
      jobDescription: this.jobDescription,
      status: JobStatus.Created,
      priority: JobPriority.Low,
      startDate: this.startDate,
      estimatedCost: this.estimatedCost,
      actualCost: this.actualCost
    });
  }
}
