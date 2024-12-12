import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampaignUserTaskUpdateComponent } from './campaign-user-task-update.component';

describe('CampaignUserTaskUpdateComponent', () => {
  let component: CampaignUserTaskUpdateComponent;
  let fixture: ComponentFixture<CampaignUserTaskUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CampaignUserTaskUpdateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CampaignUserTaskUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
