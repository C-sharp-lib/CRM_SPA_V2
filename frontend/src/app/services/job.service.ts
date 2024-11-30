import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import {environment} from '../../environments/environment';
import {Job} from '../models/job';

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
  updateJob(job: Job): Observable<Job> {
    if (!job.jobId){
      throw new Error('Job ID is required for update.');
    }
    const url = `${this.baseUrl}/${job.jobId}`;
    return this.http.put<Job>(url, job).pipe(
      retry(1)
    );
  }
  deleteJob(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }


}
