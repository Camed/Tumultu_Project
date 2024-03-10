import { Route } from '@angular/router';

export const routes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./components/files-list/files-list.component').then(
        m => m.FilesListComponent
      ),
  },
];
