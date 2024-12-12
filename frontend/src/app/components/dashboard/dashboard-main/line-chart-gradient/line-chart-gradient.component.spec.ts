import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LineChartGradientComponent } from './line-chart-gradient.component';

describe('LineChartGradientComponent', () => {
  let component: LineChartGradientComponent;
  let fixture: ComponentFixture<LineChartGradientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LineChartGradientComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LineChartGradientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
