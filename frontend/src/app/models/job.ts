import {JobStatus} from './job-status';
import {JobPriority} from './job-priority';
import {Customer} from './customer';
import {User} from './user';
import {Note} from './note';

interface CustomerJobs{
  customerId: Customer;
  jobId: Job;
}

interface JobUserNotes {
  jobId: Job;
  userId: User;
  noteId: Note;
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
  customerJobs?: CustomerJobs;
  jobUserNotes?: JobUserNotes;
}

