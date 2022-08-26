import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

// export interface FileHandle{
//   file: File,
//   url
// }

@Component({
  selector: 'app-image-upload-area',
  templateUrl: './image-upload-area.component.html',
  styleUrls: ['./image-upload-area.component.scss'],
})
export class ImageUploadAreaComponent implements OnInit {
  @Output() newFileList = new EventEmitter<FileList>();
  @Input() mainImagePath: string = '';
  showBorder = false;
  constructor() {}

  ngOnInit(): void {}
  handleDrop(event: DragEvent) {
    if (event.dataTransfer?.files) {
      this.newFileList?.emit(event.dataTransfer!.files);
    }
    event.preventDefault();
    this.showBorder = false;
  }
  allowDrop(event: DragEvent) {
    event.preventDefault();
  }

  handleFileChange(event: Event) {
    const fileInput = event.target as HTMLInputElement;
    if (fileInput.files) {
      this.newFileList?.emit(fileInput.files);
    }
  }
}
