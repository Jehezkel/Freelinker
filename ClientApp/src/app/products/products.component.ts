import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
  products$: Observable<Product[]>;
  constructor(private productService: ProductsService) {
    this.products$ = productService.products$;
  }
  ngOnInit(): void {
    this.productService.getProductList().subscribe();
  }
  deleteProduct(productId: number) {
    this.productService.removeProduct(productId).subscribe();
  }
}
