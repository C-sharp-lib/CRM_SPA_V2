import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobCalendarComponent } from './job-calendar.component';

describe('JobCalendarComponent', () => {
  let component: JobCalendarComponent;
  let fixture: ComponentFixture<JobCalendarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JobCalendarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobCalendarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
