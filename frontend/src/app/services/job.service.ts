import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Job} from '../models/job';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  baseUrl: string = environment.apiUrl + "/Job";
  constructor(private http: HttpClient) { }

  createJob(job: Job): Observable<Job> {
    return this.http.post<Job>(this.baseUrl, job);
  }
  getJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(this.baseUrl);
  }
  getJob(id: number): Observable<Job> {
    return this.http.get<Job>(`${this.baseUrl}/${id}`);
  }
  updateJob(id: number, job: Job): Observable<Job> {
    return this.http.put<Job>(`${this.baseUrl}/${id}`, job);
  }
  deleteJob(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
