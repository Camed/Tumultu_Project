import { Component, Input } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidenav-item',
  standalone: true,
  imports: [MatButton],
  templateUrl: './sidenav-item.component.html',
  styleUrl: './sidenav-item.component.scss',
})
export class SidenavItemComponent {
  @Input({ required: true })
  url!: string;
  @Input({ required: true })
  text!: string;

  constructor(private router: Router) {}
  async navigate() {
    await this.router.navigateByUrl(this.url);
  }
}
