import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {ProductService} from '../../../../services';
import {Product} from '../../../../models/product';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrl: './product-create.component.css'
})
export class ProductCreateComponent {
  product: any;
  productForm: FormGroup;
  constructor(private fb: FormBuilder, private router: Router,
              private route: ActivatedRoute, private productService: ProductService) {
    this.productForm = this.fb.group({
      productId: [{ value: '', disabled: true }, Validators.required],
      name: ['', Validators.required],
      description: ['', Validators.required],
      category: ['', Validators.required],
      price: ['', Validators.required],
      upc: ['', Validators.required],
      currency: ['', Validators.required],
      quantityInStock: ['', Validators.required],
      isActive: [true, Validators.required],
      imageUrl: ['', Validators.required],
    });
  }
  onSubmit(): void {
    if(!this.productForm.invalid) {
      const newProduct: Product = {
        orderItems: undefined,
        productId: undefined,
        name: this.productForm.value.name,
        description: this.productForm.value.description,
        category: this.productForm.value.category,
        price: this.productForm.value.price,
        upc: this.productForm.value.upc,
        currency: this.productForm.value.currency,
        quantityInStock: this.productForm.value.quantityInStock,
        isActive: this.productForm.value.isActive,
        imageUrl: this.productForm.value.imageUrl
      };
      this.productService.createProduct(newProduct).subscribe(
        (response) => {
          console.log('Product added successfully', response);
          // Optionally, reset the form or show success feedback
          this.productForm.reset();
        },
        (error) => {
          console.error('Error adding product', error);
        }
      );
    }
  }
}
