import { ProductImage } from './product-image.model';

export class Product {
  ean: number;
  sku: string;
  name: string;
  ProductImages: ProductImage[];
}
