import { Component } from '@angular/core';
import { AsyncPipe, NgForOf } from '@angular/common';
import { FilesStore } from '../../../shared/stores/files.store';
import { FilesService } from '../../../api';
import { FilesFacade } from '../../facades/files.facade';
import { FileItemComponent } from '../file-item/file-item.component';
import { MatList, MatListItem } from '@angular/material/list';

@Component({
  selector: 'app-files-list',
  standalone: true,
  imports: [NgForOf, AsyncPipe, FileItemComponent, MatList, MatListItem],
  providers: [FilesFacade, FilesStore, FilesService],
  templateUrl: './files-list.component.html',
  styleUrl: './files-list.component.scss',
})
export class FilesListComponent {
  files = this.fileFacade.getFiles();
  constructor(private fileFacade: FilesFacade) {}
}
