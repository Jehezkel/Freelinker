import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  API_BASE_URL = environment.API_BASE_URL;
  constructor(private http: HttpClient) {}
  addProduct(newProduct: Product) {
    const url = `${this.API_BASE_URL}/Product`;
    console.log('jestem', newProduct, url);
    return this.http
      .post(url, newProduct)
      .subscribe((data) => console.log(data));
  }
  updateProduct(product: Product, productId: number) {
    const url = `${this.API_BASE_URL}/Product/${productId}`;
    return this.http.put(url, product);
  }
  removeProduct(productId: number) {
    const url = `${this.API_BASE_URL}/Product/${productId}`;
    return this.http.delete(url);
  }
  getProductList() {
    const url = `${this.API_BASE_URL}/Product`;
    return this.http.get(url);
  }
  getProductDetails(productId: number) {
    const url = `${this.API_BASE_URL}/Product/${productId}`;
    return this.http.get(url);
  }
}
