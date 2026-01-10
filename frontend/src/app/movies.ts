import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movie } from './models/movie';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  private apiUrl = 'http://localhost:5014/api/movies';

  constructor(private http: HttpClient) {}

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(this.apiUrl);
  }
}
