import { ProductImage } from './product-image.model';

export class Product {
  id: number;
  ean: number;
  sku: string;
  name: string;
  mainImgUrl: string;
  productImages: ProductImage[];
}
