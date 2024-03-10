import { Injectable } from '@angular/core';
import { BehaviorSubject, take } from 'rxjs';
import { File } from '../../api/models/response';

@Injectable({
  providedIn: 'root',
})
export class FilesStore {
  private files$$ = new BehaviorSubject<File[]>([]);
  public files$ = this.files$$.asObservable();

  public getFiles() {
    return this.files$.pipe(take(1));
  }
}
