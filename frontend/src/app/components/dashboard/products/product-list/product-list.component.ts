import {Component, OnInit} from '@angular/core';
import {Product} from '../../../../models/product';
import {ProductService} from '../../../../services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  constructor(private productService: ProductService) {}
  ngOnInit() {
    this.loadProducts();
  }
  loadProducts(): void {
    this.productService.getProducts().subscribe(
      (response) => {
        this.products = response;
      }, error => {
        console.error(error);
      }
    )
  }
}
