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
export class CategoryService {

 /* private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }*/

  constructor(private readonly http: HttpClient, private readonly router: Router) { }

  getOne(id: Number): Observable<CategoriesI> {
    let category!: Observable<CategoriesI>;

    category = this.http.get<CategoriesI>(environment.api + '/category/' + id);

    return category;
  }

  getAll(searchString: string = ""): Observable<CategoriesI[]> {
    return this.http.get<CategoriesI[]>(environment.api + '/category?searchString=' + searchString).pipe(
      catchError(this.errorHandler)
    );
  }

  add(category: CategoriesI): Observable<CategoriesI> {
    return this.http.post<CategoriesI>(environment.api+ '/category', category).pipe(
      catchError(this.errorHandler)
    );;
  }

  edit(category: CategoriesI): Observable<CategoriesI> {
    return this.http.put<CategoriesI>(environment.api + '/category', category).pipe(
      catchError(this.errorHandler)
    );;
  }

  delete(id: number) {
    return this.http.delete(environment.api + '/category/' + id).pipe(
      catchError(this.errorHandler)
    );;
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
