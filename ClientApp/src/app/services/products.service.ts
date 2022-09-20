import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../models/product.model';
import { environment } from '../../environments/environment';
import { BehaviorSubject, map, Observable, of, tap } from 'rxjs';
import { ProductImage } from '../models/product-image.model';
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
    return this.http.post<Product>(url, newProduct).pipe(
      tap((response: Product) => {
        this.productsSubject.next([...this.productsSubject.value, response]);
      })
    );
  }
  updateProduct(product: Product, productId: number) {
    const url = `${this.API_BASE_URL}/Product/${productId}`;
    return this.http.put(url, product).pipe(
      tap((response: Product) => {
        let arrayVal = this.productsSubject.value;
        arrayVal.splice(
          this.productsSubject.value.findIndex((p) => p.id == productId),
          1,
          response
        );
        this.productsSubject.next(arrayVal);
      })
    );
  }
  removeProduct(productId: number) {
    const url = `${this.API_BASE_URL}/Product/${productId}`;
    return this.http.delete(url).pipe(
      tap(() => {
        this.productsSubject.next(
          this.productsSubject.value.filter((p) => p.id != productId)
        );
      })
    );
  }
  getProductList() {
    const url = `${this.API_BASE_URL}/Product`;
    return this.http.get<Product[]>(url).pipe(
      tap((data) => {
        this.productsSubject.next(data);
      })
    );
  }
  getProductDetails(productId: number) {
    const url = `${this.API_BASE_URL}/Product/${productId}`;
    return this.http.get(url);
  }
  uploadProductImage(file: File) {
    const url = `${this.API_BASE_URL}/ProductImage/Upload`;
    let formData = new FormData();
    formData.append('file', file, file.name);
    // const headers = new HttpHeaders({ 'Content-Type': 'multipart/form-data' });
    return this.http.post<ProductImage>(url, formData);
  }
}
