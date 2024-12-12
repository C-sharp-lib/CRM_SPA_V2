import {User} from './user';
import {Campaign} from './campaign';
import {JobUserNotes} from './job';
import {UserTaskNotes} from './tasks';

export interface CampaignUserNotes {
  campaignId: number;
  userId: string;
  noteId: number;
  campaign: Campaign;
  user: User;
  notes: Notes;
}

export interface Notes {
  noteId: number;
  note: string;
  campaignUserNotes: CampaignUserNotes[];
  jobUserNotes: JobUserNotes[];
  userTaskNotes: UserTaskNotes[];
}
