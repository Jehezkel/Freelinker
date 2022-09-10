import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
  ProductForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private productService: ProductsService
  ) {}

  ngOnInit(): void {
    this.ProductForm = this.fb.group({
      ean: ['', Validators.required],
      sku: ['', Validators.required],
      name: ['', Validators.required],
    });
  }
  onSubmit() {
    console.log('submitted hurray', this.ProductForm.value);
    this.productService.addProduct(this.ProductForm.value);
  }
}
