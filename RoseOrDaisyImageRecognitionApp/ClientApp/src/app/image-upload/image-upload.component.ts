import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-image-upload',
  templateUrl: 'image-upload.component.html'
})

export class ImageUploadComponent implements OnInit {
  isRequesting = true;
  constructor() { }

  ngOnInit() { }
}

