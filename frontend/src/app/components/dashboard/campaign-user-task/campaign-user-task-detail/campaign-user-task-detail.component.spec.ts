import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampaignUserTaskDetailComponent } from './campaign-user-task-detail.component';

describe('CampaignUserTaskDetailComponent', () => {
  let component: CampaignUserTaskDetailComponent;
  let fixture: ComponentFixture<CampaignUserTaskDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CampaignUserTaskDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CampaignUserTaskDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
