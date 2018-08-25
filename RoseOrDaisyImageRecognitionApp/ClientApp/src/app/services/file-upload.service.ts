import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class FileUploadService {

  constructor(
    private httpClient: HttpClient
  ) { }

  // TODO: handleError, put rest api url in config
  postFile(fileToUpload: File): Observable<any> {
    const url = 'http://localhost:55315/api/image/upload';
    const formData: FormData = new FormData();
    formData.append('image', fileToUpload);
    return this.httpClient.post(url, formData);
}
}
