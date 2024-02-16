import { Component, Input } from '@angular/core';
import { File } from '../../../api/models/response';
import { MatDivider } from '@angular/material/divider';
import { MatIcon } from '@angular/material/icon';
import { MatMiniFabButton } from '@angular/material/button';
import { F } from '@angular/cdk/keycodes';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-file-item',
  standalone: true,
  imports: [MatDivider, MatIcon, MatMiniFabButton, DatePipe],
  templateUrl: './file-item.component.html',
  styleUrl: './file-item.component.scss',
})
export class FileItemComponent {
  @Input()
  file!: File;
  protected readonly F = F;
}
