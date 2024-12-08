import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ProductService} from '../../../../services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent implements OnInit {
  product: any;
  constructor(private  route: ActivatedRoute, private router: Router, private productService: ProductService) {
  }
  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.showProduct(id);
    })
  }

  showProduct(id: number) {
    this.productService.getProduct(id).subscribe(data => {
      this.product = data;
    }, error => {
      console.log(error);
    });
  }
}
