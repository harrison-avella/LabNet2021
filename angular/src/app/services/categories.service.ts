import { Injectable } from '@angular/core';

import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { CategoriesI } from '../models/categories.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  /* private httpOptions = {
     headers: new HttpHeaders({ 'Content-Type': 'application/json' })
   }*/

  constructor(private readonly http: HttpClient, private readonly router: Router) { }

  getOne(id: Number): Observable<CategoriesI> {
    let category!: Observable<CategoriesI>;

    category = this.http.get<CategoriesI>(environment.api + 'Categories/' + id);

    return category;
  }

  get(): Observable<CategoriesI[]> {
    return this.http.get<CategoriesI[]>(environment.api + 'Categories/').pipe(
      catchError(this.errorHandler)
    );
  }

  post(category: CategoriesI): Observable<CategoriesI> {
    return this.http.post<CategoriesI>(environment.api + 'Categories/', category).pipe(
      catchError(this.errorHandler)
    );
  }

  put(category: CategoriesI): Observable<CategoriesI> {
    return this.http.put<CategoriesI>(environment.api + 'Categories/', category).pipe(
      catchError(this.errorHandler)
    );
  }

  delete(id: number) {
    return this.http.delete(environment.api + 'Categories/' + id).pipe(
      catchError(this.errorHandler)
    );
  }

  private errorHandler(error: HttpErrorResponse) {

    let errorMessage = '';
    if (error.error instanceof ErrorEvent) { // client side
      errorMessage = error.error.message;
    } else { // server side
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
