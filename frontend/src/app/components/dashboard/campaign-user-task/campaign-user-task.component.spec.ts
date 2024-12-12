import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampaignUserTaskComponent } from './campaign-user-task.component';

describe('CampaignUserTaskComponent', () => {
  let component: CampaignUserTaskComponent;
  let fixture: ComponentFixture<CampaignUserTaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CampaignUserTaskComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CampaignUserTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
