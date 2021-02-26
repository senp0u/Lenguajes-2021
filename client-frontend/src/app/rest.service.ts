import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpResponse, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import * as moment from 'moment';

const endpoint = 'http://localhost:8080/api';

@Injectable({
  providedIn: 'root'
})

export class RestService {

  token: string = '';

  constructor(private http: HttpClient) { }

  getHeaders() {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization' : localStorage.getItem('id_token')
    });
  }

  private extractData(res: Response){
    let body = res;
    return body || {};

  }
  
  login(email: string, password: string): Observable<any> {
    let params = new HttpParams();
    let headers = new Headers();
    params.append("email", email);
    params.append("password", password);
    return this.http.post<any>(endpoint + '/login?email=' + email + '&password=' + password,
      { "email": email, "password": password }, { observe: "response" }).pipe(tap(
        response => {
          console.log(moment().add(720, "minutes").format('LLL'));
          localStorage.setItem("expires_at", JSON.stringify(moment().add(720, "minutes")));
          localStorage.setItem('id_token',  response.headers.get('Authorization'));
      }));
  }

  getClientByEmail(): Observable<any> {
    const httpOptions = {
      headers: this.getHeaders()
    };
    return this.http.get(endpoint + '/issue/get/', httpOptions).pipe(
      map(this.extractData),
      catchError(this.handleError<any>('getClient'))
    );
  }

  addClient(client): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<any>(endpoint + '/client/add', JSON.stringify(client), httpOptions).pipe(
      tap((client) => console.log('added client')));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      console.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    }

  }

  getIssues(clientId): Observable<any> {
    const httpOptions = {
      headers: this.getHeaders()
    };
    console.log(clientId);
    return this.http.get(endpoint + '/issue/client/'+clientId, httpOptions).pipe(
      map(this.extractData),
      catchError(this.handleError<any>('list Issues'))
    );
  }


  getServices(): Observable<any> {
    const httpOptions = {
      headers: this.getHeaders()
    };
    return this.http.get(endpoint + '/service/get', httpOptions).pipe(
      map(this.extractData),
      catchError(this.handleError<any>('list Services'))
    );
  }

  addIssue(issue): Observable<any> {
    const httpOptions = {
      headers: this.getHeaders()
    };
    return this.http.post<any>(endpoint + '/issue/addIssue', JSON.stringify(issue), httpOptions).pipe(
      tap((issue) => console.log('added issue'))
    );
  }

  getNotes(): Observable<any> {
    return this.http.get(endpoint + '/note/notes').pipe(
      catchError(this.handleError<any>('list Notes'))
    );
  }

  addNote(note): Observable<any> {
    const httpOptions = {
      headers: this.getHeaders()
    };
    console.log(note);
    return this.http.post<any>(endpoint + '/note/add', JSON.stringify(note), httpOptions).pipe(
      tap((note) => console.log('added note')),
      catchError(this.handleError<any>('addNote'))
    );
  }

  public isLoggedIn() {
    return moment().isBefore(this.getExpiration());
  }

getExpiration() {
  const expiration = localStorage.getItem("expires_at");
  const expiresAt = JSON.parse(expiration);
  return expiresAt;
  } 

logout() {
  localStorage.removeItem("id_token");
  localStorage.removeItem("expires_at");
}
}
