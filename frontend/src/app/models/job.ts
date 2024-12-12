import {JobStatus} from './job-status';
import {JobPriority} from './job-priority';
import {Customer} from './customer';
import {User} from './user';
import {Notes} from './note';
import {Tasks} from './tasks';

export interface CustomerJobs{
  customerJobsId: number;
  customerId: number;
  jobId: number;
  customer: Customer;
  jobs: Job;
}

export interface JobUserNotes {
  jobId: number;
  userId: string;
  noteId: number;
  job: Job;
  user: User;
  notes: Notes;
}
export interface JobUserTasks {
  jobUserTasksId: number;
  userId: string;
  taskId: number;
  jobId: number;
  user: User;
  task: Tasks;
  job: Job;
}
export interface Job {
  jobId: number;
  jobTitle: string;
  jobDescription: string;
  jobStatus: JobStatus;
  startDate: Date;
  endDate: Date;
  priority: JobPriority;
  estimatedCost: number;
  actualCost: number;
  customerJobs: CustomerJobs[];
  jobUserNotes: JobUserNotes[];
  jobUserTasks: JobUserTasks[];
}


