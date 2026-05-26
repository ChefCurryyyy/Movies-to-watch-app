import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { MoviesService } from '../../services/movies';
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
  priorityMap: Record<number, string> = {
    1: 'High',
    2: 'Medium',
    3: 'Low'
  };
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
        this.error = 'Failed to load movies.';
        this.loading = false;
      }
    })
  }
}
