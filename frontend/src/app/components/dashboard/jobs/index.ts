import {JobListComponent} from './job-list/job-list.component';
import {JobModalFormComponent} from './job-modal-form/job-modal-form.component';
import {JobCreateComponent} from './job-create/job-create.component';
import {JobSearchComponent} from './job-search/job-search.component';
import {JobCalendarComponent} from './job-calendar/job-calendar.component';
import {JobDetailsComponent} from './job-detail/job-details.component';
import {JobsComponent} from './jobs.component';
import {JobUpdateModalFormComponent} from './job-update-modal-form/job-update-modal-form.component';

export const components: any[] = [
  JobListComponent,
  JobCreateComponent,
  JobSearchComponent,
  JobCalendarComponent,
  JobDetailsComponent,
  JobModalFormComponent,
  JobsComponent,
  JobUpdateModalFormComponent
];


export * from './job-list/job-list.component';
export * from './job-modal-form/job-modal-form.component';
export * from './job-create/job-create.component';
export * from './job-search/job-search.component';
export * from './job-calendar/job-calendar.component';
export * from './job-detail/job-details.component';
export * from './jobs.component';
export * from './job-update-modal-form/job-update-modal-form.component';
