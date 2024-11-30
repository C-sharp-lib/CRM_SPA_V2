import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobModalFormComponent } from './job-modal-form.component';

describe('JobModalFormComponent', () => {
  let component: JobModalFormComponent;
  let fixture: ComponentFixture<JobModalFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JobModalFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobModalFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
