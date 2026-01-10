import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { MoviesService } from '../../movies';
import { Movie } from '../../models/movie';

import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-movies-index',
  standalone: true,
  imports: [
    MatTableModule,
    MatCardModule,
    MatProgressSpinnerModule,
    DatePipe
  ],
  templateUrl: './index.html',
  styleUrl: './index.css',
})
export class MoviesIndex implements OnInit {
  movies: Movie[] = [];
  displayedColumns = ['title', 'priority', 'createdAt'];
  loading = true;
  error: string | null = null;

  constructor(private moviesService: MoviesService) {}

  ngOnInit() {
    this.moviesService.getMovies().subscribe({
      next: data => {
        this.movies = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to laod movies.';
        this.loading = false;
      }
    })
  }
}
