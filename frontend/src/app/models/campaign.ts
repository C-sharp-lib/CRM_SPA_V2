import {User} from './user';
import {Notes} from './note';
import {Tasks} from './tasks';

export interface CampaignUserNotes {
  campaignUserNoteId: number;
  campaignId: number;
  userId: string;
  noteId: number;
  campaign: Campaign;
  user: User;
  notes: Notes;
}

export interface CampaignUserTasks {
  campaignUserTaskId: number;
  campaignId: number;
  userId: string;
  taskId: number;
  campaign: Campaign;
  user: User;
  task: Tasks;
}

export interface Campaign {
  campaignId: number;
  title: string;
  description: string;
  type: string;
  status: string;
  startDate: Date;
  endDate: Date;
  budget: number;
  spend: number;
  createdAt: Date;
  targetAudience: string;
  channel: string;
  goals: string;
  revenueTarget: number;
  actualRevenue: number;
  impressions: number;
  clicks: number;
  leadsGenerated: number;
  conversions: number;
  roi: number;
  campaignUserNotes: CampaignUserNotes[];
  campaignUserTasks: CampaignUserTasks[];
}
