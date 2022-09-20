import {
  Component,
  ElementRef,
  EventEmitter,
  HostListener,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { EventType } from '@angular/router';
import {
  BehaviorSubject,
  fromEvent,
  merge,
  Observable,
  of,
  tap,
  zip,
} from 'rxjs';
import { ProductImage } from 'src/app/models/product-image.model';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-gallery',
  templateUrl: './product-gallery.component.html',
  styleUrls: ['./product-gallery.component.scss'],
})
export class ProductGalleryComponent implements OnInit {
  @Output() prodImgEmitter = new EventEmitter<ProductImage[]>();
  images$ = new BehaviorSubject<ProductImage[]>([]);
  private images: ProductImage[] = [];
  constructor(private prodService: ProductsService) {}
  ngOnInit(): void {
    this.images$.subscribe((data) => this.prodImgEmitter.emit(data));
    // this.imagesSubject$.pipe(tap((imgs) => console.log(imgs))).subscribe();
  }
  pushNewFiles(newFileList: FileList) {
    this.preparePreview(newFileList);
    this.uploadFiles(newFileList);
  }
  preparePreview(fileList: FileList) {
    const fileReaders: FileReader[] = [];
    for (let index = 0; index < fileList.length; index++) {
      const reader = new FileReader();
      const currentFile = fileList[index];
      let currentProdImage = new ProductImage();
      currentProdImage.fileName = currentFile.name;
      currentProdImage.isLoading = true;
      reader.readAsDataURL(currentFile);
      reader.onloadend = (e) => {
        currentProdImage.imgPreview = reader.result as ArrayBuffer;
        this.images.push(currentProdImage);
        this.images$.next(this.images);
      };
      fileReaders.push(reader);
    }
  }
  uploadFiles(fileList: FileList) {
    for (let index = 0; index < fileList.length; index++) {
      const currentFile = fileList[index];
      this.prodService
        .uploadProductImage(currentFile)
        .subscribe((prodImg) =>
          this.replacePreviewWithResult(currentFile.name, prodImg)
        );
    }
  }
  replacePreviewWithResult(fName: string, prodImg: ProductImage) {
    const indexToBeReplaced = this.images.findIndex(
      (p) => p.fileName === fName && p.isLoading == true
    );
    this.images.splice(indexToBeReplaced, 1, prodImg);
    this.images$.next(this.images);
  }
  handleFileInput(event: Event) {
    const fileInput = event.target as HTMLInputElement;
    if (fileInput.files) {
      this.pushNewFiles(fileInput.files);
    }
  }
}
