import { Component, EventEmitter, Output } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { MatToolbar } from '@angular/material/toolbar';
import { MatIconButton } from '@angular/material/button';

@Component({
  selector: 'app-toolbar',
  standalone: true,
  imports: [MatIcon, MatToolbar, MatIconButton],
  templateUrl: './toolbar.component.html',
  styleUrl: './toolbar.component.scss',
})
export class ToolbarComponent {
  @Output() toggleSideNavEventEmitter = new EventEmitter<string>();
  toggleSideNav() {
    this.toggleSideNavEventEmitter.emit();
  }
}
