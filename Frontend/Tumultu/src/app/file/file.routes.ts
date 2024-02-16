import { Route } from '@angular/router';

export const FILE_ROUTERS: Route[] = [
  {
    path: '',
    loadChildren: () => import('./list/list.routes').then(m => m.routes),
  },
];
