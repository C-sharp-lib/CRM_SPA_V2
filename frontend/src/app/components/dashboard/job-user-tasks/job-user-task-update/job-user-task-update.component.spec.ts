import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobUserTaskUpdateComponent } from './job-user-task-update.component';

describe('JobUserTaskUpdateComponent', () => {
  let component: JobUserTaskUpdateComponent;
  let fixture: ComponentFixture<JobUserTaskUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JobUserTaskUpdateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobUserTaskUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
