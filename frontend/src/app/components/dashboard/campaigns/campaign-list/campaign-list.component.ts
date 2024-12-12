import {Component, OnInit} from '@angular/core';
import {Campaign} from '../../../../models/campaign';
import {CampaignService} from '../../../../services';

@Component({
  selector: 'app-campaign-list',
  templateUrl: './campaign-list.component.html',
  styleUrl: './campaign-list.component.css'
})
export class CampaignListComponent implements OnInit {
  campaigns: Campaign[] = [];
  constructor(private campaignService: CampaignService) {
  }
  ngOnInit() {
    this.showCampaigns();
  }

  showCampaigns() {
    this.campaignService.getCampaigns().subscribe(
      (response) => {
        this.campaigns = response;
      }, (error) => {
        console.error(error);
      }
    )
  }
}
