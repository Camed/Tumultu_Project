import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'files',
    loadChildren: () => import('./file/file.routes').then(m => m.FILE_ROUTERS),
  },
];
