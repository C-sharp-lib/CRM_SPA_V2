import {User} from './user';
import {Note} from './note';

interface CampaignUserNotes {
  campaignUserNoteId: number;
  campaignId: Campaign;
  userId: User;
  noteId: Note;
}

interface CampaignUserTasks {
  campaignUserTaskId: number;
  campaignId: Campaign;
  userId: User;
  taskId: Task;
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
  spendd: number;
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
  campaignUserNotes: CampaignUserNotes;
  campaignUserTasks: CampaignUserTasks;
}
