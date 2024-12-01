import {Component, OnInit} from '@angular/core';
import {AccountService} from '../../../../services';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css'
})
export class UserDetailComponent implements OnInit {
  user: any;
  userId: string | null = null;
  constructor(private route: ActivatedRoute) {
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.userId = params.get('id');
    });
  }
}
