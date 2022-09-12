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
  ) {}

  ngOnInit(): void {
    this.ProductForm = this.fb.group({
      ean: [this.Product.ean, Validators.required],
      sku: [this.Product.sku, Validators.required],
      name: [this.Product.name, Validators.required],
    });
    const url = this.route.snapshot.url;
    this.Mode = url[1].path;
    if (this.Mode == 'edit') {
      const id = url[2].path;
      this.productService
        .getProductDetails(Number(id))
        .subscribe((data: Product) => {
          console.log(data);
          this.Product = data;
          this.refreshFormValues();
        });
    } else {
    }
  }
  refreshFormValues() {
    this.ProductForm.controls.sku.setValue(this.Product.sku);
    this.ProductForm.controls.ean.setValue(this.Product.ean);
    this.ProductForm.controls.name.setValue(this.Product.name);
  }
  onSubmit() {
    console.log('submitted hurray', this.ProductForm.value);
    if (this.Mode === 'new') {
      console.log('to new');
      this.productService.addProduct(this.ProductForm.value).subscribe(() => {
        this.router.navigate(['products']);
      });
    }
    if (this.Mode === 'edit') {
      console.log('to edit');

      this.productService
        .updateProduct(this.ProductForm.value, this.Product.id)
        .subscribe(() => this.router.navigate(['products']));
    }
  }
}
