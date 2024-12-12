import {Chart, registerables} from 'chart.js';
import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';


@Component({
  selector: 'app-line-chart-gradient',
  templateUrl: './line-chart-gradient.component.html',
  styleUrl: './line-chart-gradient.component.css'
})
export class LineChartGradientComponent implements OnInit {
  constructor(private elementRef: ElementRef) {
    Chart.register(...registerables);
  }
  ngOnInit() {
    this.lineChart();
  }
  lineChart() {
    let lineCtx = this.elementRef.nativeElement.querySelector("#lineGradient").getContext("2d");
    const gradient1 = lineCtx.createLinearGradient(0, 0, 0, 400);
    const gradient2 = lineCtx.createLinearGradient(0, 0, 0, 400);
    gradient1.addColorStop(0, 'rgba(255, 0, 0, 0.5)');
    gradient1.addColorStop(1, 'rgba(0, 255, 0, 0.5)');
    gradient2.addColorStop(0, 'rgba(0, 0, 255, 0.5)');
    gradient2.addColorStop(1, 'rgba(0, 255, 0, 0.5)');
    new Chart(
      lineCtx,
      {
        type: 'line',
        data: {
          labels: ["Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
          datasets: [
            {
              label: 'Mobile Apps',
              data: [50, 40, 300, 220, 500, 250, 400, 230, 500],
              backgroundColor: gradient1,
              borderColor: 'rgba(255, 0, 0, 1)',
              borderWidth: 1,
            },
            {
              label: 'Websites',
              data: [30, 90, 40, 140, 290, 290, 340, 230, 400],
              backgroundColor: gradient2,
              borderColor: 'rgba(0, 255, 0, 1)',
              borderWidth: 1,
            }
          ],
        },
        options: {
          responsive: true,
        }
      }
    );
  }
}
