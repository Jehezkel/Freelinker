import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/product.model';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-form-general',
  templateUrl: './product-form-general.component.html',
  styleUrls: ['./product-form-general.component.scss'],
})
export class ProductFormGeneralComponent implements OnInit {
  Product: Product = new Product();
  ProductForm: FormGroup;
  Mode: string = 'new';
  constructor(
    private fb: FormBuilder,
    private productService: ProductsService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.rebindModel;
  }

  ngOnInit(): void {
    console.log(this.route);
    const url = this.route.snapshot.url;
    this.Mode = url[1].path;
    this.rebindModel;
    if (this.Mode == 'edit') {
      const id = url[2].path;
      this.productService
        .getProductDetails(Number(id))
        .subscribe((data: Product) => {
          console.log(data);
          this.Product = data;
          this.rebindModel();
        });
    } else {
    }
  }
  rebindModel() {
    this.ProductForm = this.fb.group({
      ean: [this.Product.ean, Validators.required],
      sku: [this.Product.sku, Validators.required],
      name: [this.Product.name, Validators.required],
    });
  }
  onSubmit() {
    console.log('submitted hurray', this.ProductForm.value);
    if (this.Mode === 'new') {
      console.log('to new');
      this.productService.addProduct(this.ProductForm.value);
      this.router.navigate(['products']);
    }
    if (this.Mode === 'edit') {
      console.log('to edit');

      this.productService.updateProduct(
        this.ProductForm.value,
        this.Product.id
      );
      this.router.navigate(['products']);
    }
  }
}
