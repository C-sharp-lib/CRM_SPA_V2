import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobUserTasksComponent } from './job-user-tasks.component';

describe('JobUserTasksComponent', () => {
  let component: JobUserTasksComponent;
  let fixture: ComponentFixture<JobUserTasksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JobUserTasksComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobUserTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
