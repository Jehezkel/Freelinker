import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';
import { environment } from '../../environments/environment';
import { BehaviorSubject, map, Observable, of } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private API_BASE_URL = environment.API_BASE_URL;
  private productsSubject: BehaviorSubject<Product[]> = new BehaviorSubject<
    Product[]
  >([]);
  products$: Observable<Product[]> = this.productsSubject.asObservable();

  constructor(private http: HttpClient) {}
  addProduct(newProduct: Product) {
    const url = `${this.API_BASE_URL}/Product`;
    console.log('jestem', newProduct, url);

    return this.http.post(url, newProduct).subscribe((data) => {
      const updatedValue = [...this.productsSubject.value, newProduct];
      this.productsSubject.next(updatedValue);
    });
  }
  updateProduct(product: Product, productId: number) {
    const url = `${this.API_BASE_URL}/Product/${productId}`;
    return this.http.put(url, product).subscribe((data) => {
      let result = this.productsSubject.value;
      result = result.filter((p) => p.id != productId);
      result.push(product);
      this.productsSubject.next(result);
    });
  }
  removeProduct(productId: number) {
    const url = `${this.API_BASE_URL}/Product/${productId}`;
    return this.http.delete(url).subscribe((data) => {
      const updatedValue = this.productsSubject.value.filter(
        (p) => p.id != productId
      );
      this.productsSubject.next(updatedValue);
    });
  }
  getProductList() {
    const url = `${this.API_BASE_URL}/Product`;
    return this.http.get<Product[]>(url).subscribe((data) => {
      console.log('xD', data);
      this.productsSubject.next(data);
    });
  }
  getProductDetails(productId: number) {
    const url = `${this.API_BASE_URL}/Product/${productId}`;
    return this.http.get(url);
  }
}
