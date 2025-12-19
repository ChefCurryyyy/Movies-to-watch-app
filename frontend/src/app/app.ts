import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {MoviesIndex} from './movies/index';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MoviesIndex],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('frontend');
}
