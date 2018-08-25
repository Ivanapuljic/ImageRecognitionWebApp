import { Component, OnInit } from '@angular/core';
import { FileUploadService } from '../services/file-upload.service';

@Component({
  selector: 'app-image-upload',
  templateUrl: 'image-upload.component.html',
  styleUrls: ['image-upload.component.scss']
})

export class ImageUploadComponent implements OnInit {
  isRequesting = false;
  result: string;
  constructor(
    private fileUploadService: FileUploadService
  ) { }

  ngOnInit() { }

  // TODO: error handling
  handleFileInput(files: FileList) {
    this.isRequesting = true;
    const file = files.item(0);
    this.fileUploadService.postFile(file)
      .subscribe(res => {
        console.log(res);
        this.isRequesting = false;
        this.result = res.name;

      });
  }
}

