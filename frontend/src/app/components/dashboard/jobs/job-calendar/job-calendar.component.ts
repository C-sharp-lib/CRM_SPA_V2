import {Component, OnInit} from '@angular/core';
import {CalendarOptions, EventClickArg, EventInput} from '@fullcalendar/core';
import interactionPlugin from '@fullcalendar/interaction';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import listPlugin from '@fullcalendar/list';
import {JobService} from '../../../../services';
import {Job} from '../../../../models/job';
import {JobStatus} from '../../../../models/job-status';
import {JobPriority} from '../../../../models/job-priority';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ModalService} from '../../../../services/modal.service';
import {JobModalFormComponent} from '../job-modal-form/job-modal-form.component';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {JobUpdateModalFormComponent} from '../job-update-modal-form/job-update-modal-form.component';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-job-calendar',
  templateUrl: './job-calendar.component.html',
  styleUrl: './job-calendar.component.css'
})
export class JobCalendarComponent implements OnInit {
  calendarOptions: CalendarOptions;
  jobs: any[] = [];
  isFormVisible = false;
  jobStatus = Object.values(JobStatus);
  priority = Object.values(JobPriority);
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
  constructor(private route: ActivatedRoute, private fb: FormBuilder, private jobService: JobService, private modalService: ModalService) {}
  ngOnInit() {
    this.loadJobs();
    this.initializeCalendarOptions();
  }
  closeForm() {
    this.isFormVisible = false;
  }
  loadJobs() {
    this.jobService.getJobs().subscribe((jobs) => {
      this.jobs = jobs;
      this.initializeCalendarOptions();
    });
  }
  initializeCalendarOptions() {
    this.calendarOptions = {
      initialView: 'dayGridMonth',
      plugins: [interactionPlugin, dayGridPlugin, timeGridPlugin, listPlugin],
      events: this.transformJobsToEvents(this.jobs),
      headerToolbar: {
        left: 'prev,next today',
        center: 'title',
        right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek',
      },
      editable: true,
      selectable: true,
      eventClick: this.handleEventClick.bind(this),
      dateClick: this.handleDateClick.bind(this),
      eventDrop: this.handleEventDrop.bind(this),
      eventResize: this.handleEventResize.bind(this),
      eventContent: this.renderEventContent.bind(this),
    };
  }

  handleDateClick(arg: any): void {
    const modalRef = this.modalService.openModal(JobModalFormComponent);
    modalRef.componentInstance.startDate = arg.dateStr;
    modalRef.result.then((result) => {
      if (result) {
        const newEvent = {
          jobTitle: result.jobTitle || 'New Job',
          jobDescription: result.jobDescription || '',
          startDate: arg.dateStr,
          endDate: arg.dateStr,
          actualCost: result.actualCost || 0.0,
          estimatedCost: result.estimatedCost || 0.0,
          jobId: undefined,
          jobStatus: result.jobStatus || 'Created',
          priority: result.priority || 'Low',
          customerJobs: [],
          jobUserNotes:[],
          jobUserTasks: [],
        };
        this.jobService.createJob(newEvent).subscribe(
          (response) => {
            console.log('Event saved successfully', response);
            // Optionally, update the calendar view
          },
          (error) => {
            console.error('Error saving event', error);
          }
        );
      }
    }).catch(() => {
      console.log('Modal dismissed');
    });
  }

  transformJobsToEvents(jobs: Job[]): EventInput {
    return jobs.map((job) => ({
      id: job.jobId?.toString(),
      title: job.jobTitle,
      start: job.startDate,
      end: job.endDate,
      color: this.getEventColor(job),
      extendedProps: {
        job: job
      }
    }));
  }
  handleEventClick(event: any) {
    const modalRef = this.modalService.openModal(JobUpdateModalFormComponent);
    modalRef.componentInstance.event = event;
    modalRef.result
      .then((updatedEvent) => {
        this.jobService.updateJob(event.id, updatedEvent).subscribe({
          next: () => {
            console.log('Event updated successfully', event);
          },
          error: (err) => {
            console.error('Error updating event', err);
          },
        });
      })
      .catch((error) => {
        console.log('Modal dismissed', error);
      });
  }
  handleEventDrop(arg) {
    const job: Job = arg.event.extendedProps.job;
    job.startDate = arg.event.start;
    job.endDate = arg.event.end;
    this.jobService.updateJob(job.jobId, job).subscribe((updateJob) => {
      const index = this.jobs.findIndex((j) => j.jobId === updateJob.jobId);
      this.jobs[index] = updateJob;
    });
  }

  handleEventResize(arg) {
    const job: Job = arg.event.extendedProps.job;
    job.endDate = arg.event.end;

    this.jobService.updateJob(job.jobId, job).subscribe((updatedJob) => {
      const index = this.jobs.findIndex((j) => j.jobId === updatedJob.jobId);
      this.jobs[index] = updatedJob;
    });
  }

  renderEventContent(arg) {
    const job: Job = arg.event.extendedProps.job;
    const eventColor = this.getEventColor(job);
    const jobTitle = job.jobTitle;
    const startDate = new Date(job.startDate);
    const endDate = new Date(job.endDate);
    const jobTime = "Start: " + startDate.toLocaleDateString() + " - End: " + endDate.toLocaleDateString();

    const customHtml = `
    <div class="p-1 text-white ubuntu-bold" style="background-color: ${eventColor}">
      <b>${jobTitle.slice(0,7)} | <i>${jobTime}</i></b>
    </div>
  `;

    return { html: customHtml };
  }

  getEventColor(job: Job): string {
    // Assign a color based on some property or relationship
    switch (job.priority) {
      case JobPriority.Low:
        return 'dodgerblue';
      case JobPriority.Medium:
        return 'darkorange';
      case JobPriority.High:
        return 'tomato';
      case JobPriority.Critical:
        return 'darkred';
      default:
        return 'gray';
    }
  }

}
