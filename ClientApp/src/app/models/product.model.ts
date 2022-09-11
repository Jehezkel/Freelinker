import { ProductImage } from './product-image.model';

export class Product {
  id: number;
  ean: number;
  sku: string;
  name: string;
  ProductImages: ProductImage[];
}
