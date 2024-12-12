import {JobUserTasks, UserTaskNotes} from './tasks';
import {CampaignUserNotes, CampaignUserTasks} from './campaign';
import {JobUserNotes} from './job';
import {Customer} from './customer';

export interface UserRoles {
  userRoles: UserRoles[];
}
export interface CustomerUsers {
  customerUserId: number;
  userId: string;
  customerId: number;
  user: User;
  customer: Customer;
}

export interface User {
  id: string;
  imageUrl?: string;
  userName: string;
  email: string;
  password: string;
  phoneNumber?: string;
  phoneNumberConfirmed?: boolean;
  twoFactorEnabled?: boolean;
  lockoutEnabled?: boolean;
  accessFailedCount?: number;
  firstName?: string;
  middleName?: string;
  lastName?: string;
  dob?: Date;
  isActive?: boolean;
  hireDate?: Date;
  confirmPassword: string;
  userRoles: UserRoles[];
  customerUsers: CustomerUsers[];
  userTaskNotes: UserTaskNotes[];
  campaignUserNotes: CampaignUserNotes[];
  campaignUserTasks: CampaignUserTasks[];
  jobUserNotes: JobUserNotes[];
  jobUserTasks: JobUserTasks[];
}

