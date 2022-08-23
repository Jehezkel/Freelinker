import {
  Component,
  ElementRef,
  EventEmitter,
  HostListener,
  OnInit,
  ViewChild,
} from '@angular/core';
import { EventType } from '@angular/router';

@Component({
  selector: 'app-product-gallery',
  templateUrl: './product-gallery.component.html',
  styleUrls: ['./product-gallery.component.scss'],
})
export class ProductGalleryComponent implements OnInit {
  fileListOutput: EventEmitter<FileList> | undefined;
  fileList: File[] = [];
  constructor() {}
  ngOnInit(): void {
    this.fileListOutput?.subscribe((fl) => {
      console.log('xD', Array.from(fl));
    });
  }
  pushNewFiles(newFileList: FileList) {
    console.log('ParentNewFiles', newFileList);
    for (let index = 0; index < newFileList.length; index++) {
      const element = newFileList[index];
      this.fileList.push(element);
    }
    console.log('full array ', this.fileList);
  }
}
