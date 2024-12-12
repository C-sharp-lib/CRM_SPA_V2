import {CampaignUserTasks} from './campaign';
import {User} from './user';
import {Notes} from './note';
import {Job} from './job';


export interface UserTaskNotes {
  userTaskNoteId: number;
  userId: string;
  taskId: number;
  noteId: number;
  user: User;
  task: Tasks;
  note: Notes;
}
export interface JobUserTasks {
  jobUserTaskId: number;
  jobId: number;
  userId: string;
  taskId: number;
  user: User;
  task: Tasks;
  job: Job;
}

export interface Tasks {
  taskId: number;
  title: string;
  description: string;
  priority: TaskPriority;
  status: TaskStatus;
  dueDate: Date;
  completionDate?: Date;
  userTaskNotes: UserTaskNotes[];
  campaignUserTasks: CampaignUserTasks[];
  jobUserTasks: JobUserTasks[];
}
export enum TaskPriority {
  Low = 'Low',
  Medium = 'Medium',
  High = 'High',
  Critical = 'Critical'
}
export enum TaskStatus {
  Created = 'Created',
  InProgress = 'InProgress',
  Pending = 'Pending',
  Completed = 'Completed',
  Running = 'Running',
  Cancelled = 'Cancelled',
  Failed = 'Failed',
  Queued = 'Queued',
}


