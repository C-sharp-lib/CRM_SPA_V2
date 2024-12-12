import {Component, Input, OnInit} from '@angular/core';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Job} from '../../../../models/job';
import {JobPriority} from '../../../../models/job-priority';
import {JobStatus} from '../../../../models/job-status';
import {ActivatedRoute} from '@angular/router';
import {JobService} from '../../../../services';

@Component({
  selector: 'app-job-update-modal-form',
  templateUrl: './job-update-modal-form.component.html',
  styleUrl: './job-update-modal-form.component.css'
})
export class JobUpdateModalFormComponent implements OnInit {
  @Input() event:Job;
  job: Job;
  eventForm: FormGroup;
  constructor(private fb: FormBuilder, public activeModal: NgbActiveModal, private route: ActivatedRoute, private jobService: JobService) {
    this.eventForm = this.fb.group({
      jobId: [{ value: '', disabled: true }, Validators.required],
      jobTitle: ['', Validators.required],
      jobDescription: ['', Validators.required],
      jobStatus: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      priority: ['', Validators.required],
      actualCost: ['', Validators.required],
      estimatedCost: ['', Validators.required],
    })
  }

  ngOnInit() {
    if(this.event) {
      this.eventForm.patchValue({
        jobId: this.event.jobId,
        jobTitle: this.event.jobTitle,
        jobDescription: this.event.jobDescription,
        jobStatus: this.event.jobStatus,
        startDate: new Date(this.event.startDate).toLocaleDateString(),
        endDate: new Date(this.event.endDate).toLocaleDateString(),
        priority: this.event.priority,
        estimatedCost: this.event.estimatedCost,
        actualCost: this.event.actualCost,
      });
    }
  }

  save() {
    this.activeModal.close(this.eventForm.value);
  }
  dismiss() {
    this.activeModal.dismiss();
  }

  protected readonly JobPriority = JobPriority;
  protected readonly JobStatus = JobStatus;
}
