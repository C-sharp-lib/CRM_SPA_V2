import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {Campaign, CampaignUserNotes, CampaignUserTasks} from '../models/campaign';

@Injectable({
  providedIn: 'root'
})
export class CampaignService {
  baseUrl: string = environment.apiUrl + "/Campaign";
  constructor(private http: HttpClient) { }

  getCampaignUserTasks(): Observable<any> {
    return this.http.get<CampaignUserTasks[]>(`${this.baseUrl}/campaign-user-tasks`);
  }
  getCampaignUserNotes(): Observable<any> {
    return this.http.get<CampaignUserNotes[]>(`${this.baseUrl}/campaign-user-notes`);
  }
  getCampaigns(): Observable<Campaign[]> {
    return this.http.get<Campaign[]>(`${this.baseUrl}/campaigns`);
  }
  getCampaign(id: number): Observable<Campaign> {
    return this.http.get<Campaign>(`${this.baseUrl}/campaign-details/${id}`);
  }
  createCampaign(campaign: Campaign): Observable<Campaign> {
    return this.http.post<Campaign>(`${this.baseUrl}/create-campaign`, campaign);
  }
  updateCampaign(id: number, campaign: Campaign): Observable<any> {
    const url = `${this.baseUrl}/update-campaign/${id}`;
    return this.http.put(url, campaign);
  }
}
