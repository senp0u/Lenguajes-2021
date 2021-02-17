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

  getClients(): Observable<any> {
    return this.http.get(endpoint + 'client/clients').pipe(
     catchError(this.handleError<any>('list clients'))
   );
   }
  
}
