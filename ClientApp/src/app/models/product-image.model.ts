import { Product } from './product.model';

export class ProductImage {
  id: number;
  fileName: string;
  storedFileName: string;
  product: Product;
  // private _imgUrl: string;
  imgPreview: ArrayBuffer;
  isLoading: boolean = false;
  imgUrl: string;
  get imgSource(): string | ArrayBuffer {
    return this.imgUrl ?? this.imgPreview;
  }
}
