import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {CampaignService} from '../../../../services';
import {Campaign, CampaignUserTasks} from '../../../../models/campaign';


@Component({
  selector: 'app-campaign-detail',
  templateUrl: './campaign-detail.component.html',
  styleUrl: './campaign-detail.component.css'
})
export class CampaignDetailComponent implements OnInit {
  campaign: Campaign;
  constructor(private route: ActivatedRoute, private campaignService: CampaignService, private router: Router) {}
  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.showCampaignDetails(id);
    });
  }
  showCampaignDetails(id: number) {
    this.campaignService.getCampaign(id).subscribe(
      (data) => {
        this.campaign = data;
        this.campaign.campaignUserTasks = data.campaignUserTasks;
      }, (error) => {
        console.error(error);
      }
    );
  }
}
