import { Routes } from '@angular/router';
import {MoviesIndex} from './movies/index';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'movies_to_watch',
    pathMatch: 'full'
  },
  {
    path: 'movies_to_watch',
    component: MoviesIndex
  }
];
