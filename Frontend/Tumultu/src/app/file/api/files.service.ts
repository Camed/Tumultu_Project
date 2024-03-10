import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from '../../../environments/environment';
import { File } from './models/response';

@Injectable({
  providedIn: 'root',
})
export class FilesService {
  constructor(private httpClient: HttpClient) {}

  public getFiles(): Observable<File[]> {
    return of([
      {
        id: '1',
        name: 'plik1.txt',
        size: 1024,
        uploadDate: new Date(),
        hash: 'abc123',
      },
      {
        id: '2',
        name: 'plik2.jpg',
        size: 2048,
        uploadDate: new Date(),
        hash: 'def456',
      },
      {
        id: '3',
        name: 'plik3.pdf',
        size: 512,
        uploadDate: new Date(),
        hash: 'ghi789',
      },
      {
        id: '4',
        name: 'plik4.docx',
        size: 4096,
        uploadDate: new Date(),
        hash: 'jkl012',
      },
      {
        id: '5',
        name: 'plik5.png',
        size: 8192,
        uploadDate: new Date(),
        hash: 'mno345',
      },
    ]);
    // return this.httpClient.get<File[]>(this.endpoint('Files'));
  }

  private endpoint(endpoint: string) {
    return environment.apiBase + endpoint;
  }
}
