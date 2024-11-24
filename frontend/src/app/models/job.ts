import {JobStatus} from './job-status';
import {JobPriority} from './job-priority';

export class Job {
  jobId: number | undefined;
  customerId: number | undefined;
  jobTitle: string = '';
  jobDescription: string = '';
  jobStatus: JobStatus | undefined;
  startDate: Date | undefined;
  endDate: Date | undefined;
  assignedTo: string = '';
  priority: JobPriority | undefined;
  estimatedCost: number | undefined;
  actualCost: number | undefined;
  createdAt: Date = new Date();
  createdBy: string = '';
  lastUpdatedBy?: string = '';
  lastUpdatedDate: Date = new Date();

  constructor(init?: Partial<Job>) {
    Object.assign(this, init);
  }
}

