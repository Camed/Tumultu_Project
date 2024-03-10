import { Injectable } from '@angular/core';
import { Observable, of, switchMap } from 'rxjs';
import { FilesStore } from '../../shared/stores/files.store';
import { FilesService } from '../../api';
import { File } from '../../api/models/response';

@Injectable({
  providedIn: 'root',
})
export class FilesFacade {
  constructor(
    private filesStore: FilesStore,
    private filesService: FilesService
  ) {}

  public fetchFiles() {
    this.filesService.getFiles();
  }

  public getFiles(): Observable<File[]> {
    return this.filesStore.getFiles().pipe(
      switchMap(files => {
        if (files.length === 0) {
          return this.filesService.getFiles();
        }
        return of(files);
      })
    );
  }
}
