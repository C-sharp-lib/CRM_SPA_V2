import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobUpdateModalFormComponent } from './job-update-modal-form.component';

describe('JobUpdateModalFormComponent', () => {
  let component: JobUpdateModalFormComponent;
  let fixture: ComponentFixture<JobUpdateModalFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JobUpdateModalFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobUpdateModalFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
