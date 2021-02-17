import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpErrorResponse, HttpResponse, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

const endpoint = 'http://localhost:8080/api';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class RestService {

  result: string;
  constructor(private http: HttpClient) { }
  
  login(email: string, password: string): Observable<any> {
    console.log(endpoint+"/login");
    let params = new HttpParams();
    params.append("email", email);
    params.append("password", password);
    return this.http.post<any>(endpoint+'/login?email='+email+'&password='+password, 
    {"email": email, "password": password},{observe:"response"});
  }

  addClient (client): Observable<any> {
    console.log(client);
    return this.http.post<any>(endpoint + '/client/add', JSON.stringify(client), httpOptions).pipe(
      tap((client) => console.log('added client')),
      catchError(this.handleError<any>('addClient'))
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      console.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    }

  }

  getIssues(): Observable<any> {
    return this.http.get(endpoint + 'issue/issues').pipe(
     catchError(this.handleError<any>('list Issues'))
   );
   }

   getServices(): Observable<any> {
    return this.http.get(endpoint + 'service/services').pipe(
     catchError(this.handleError<any>('list Services'))
   );
   }

   addIssue (issue): Observable<any> {
    console.log(issue);
    return this.http.post<any>(endpoint + '/issue/add', JSON.stringify(issue), httpOptions).pipe(
      tap((issue) => console.log('added issue')),
      catchError(this.handleError<any>('addIssue'))
    );
  }

  getNotes(): Observable<any> {
    return this.http.get(endpoint + 'note/notes').pipe(
     catchError(this.handleError<any>('list Notes'))
   );
   }

   addNote(note): Observable<any> {
    console.log(note);
    return this.http.post<any>(endpoint + '/note/add', JSON.stringify(note), httpOptions).pipe(
      tap((note) => console.log('added note')),
      catchError(this.handleError<any>('addNote'))
    );
  }
  
}
