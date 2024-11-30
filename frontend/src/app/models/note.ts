import {User} from './user';
import {Campaign} from './campaign';

interface CampaignUserNotes {
  campaignId: Campaign;
  userId: User;
  noteId: Note;
}

export interface Note {
  noteId: number;
  note: string;
  campaignUserNotes: CampaignUserNotes;
}
