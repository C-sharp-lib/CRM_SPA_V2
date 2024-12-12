import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobUserTaskDetailComponent } from './job-user-task-detail.component';

describe('JobUserTaskDetailComponent', () => {
  let component: JobUserTaskDetailComponent;
  let fixture: ComponentFixture<JobUserTaskDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JobUserTaskDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobUserTaskDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
