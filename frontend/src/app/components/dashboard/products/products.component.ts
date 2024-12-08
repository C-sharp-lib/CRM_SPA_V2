import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, NavigationEnd, Router} from '@angular/router';
import {User} from '../../../models/user';
import {AccountService} from '../../../services';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {
  showMenu: boolean = false;
  constructor(private authService: AccountService, private router: Router, private route: ActivatedRoute) {
  }
  ngOnInit() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        const childRoute = this.route.firstChild;
        if (childRoute && childRoute.snapshot.data['showMenu'] !== undefined) {
          this.showMenu = childRoute.snapshot.data['showMenu'];
        } else {
          this.showMenu = false;
        }
      }
    });
  }

  showProductList(): boolean {
    if(this.router.url === '/dashboard/products/product-list') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
  showProductCreate(): boolean {
    if(this.router.url === '/dashboard/products/product-create') {
      return this.showMenu = true;
    } else {
      return this.showMenu = false;
    }
  }
}
