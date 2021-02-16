import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpErrorResponse, HttpResponse, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

const endpoint = 'http://localhost:8080/api';

@Injectable({
  providedIn: 'root'
})
export class RestService {

  result: string;
  constructor(private http: HttpClient) { }
  
  private extractData(res: Response){
    let body = res;
    return body || {};

  }

  login(email: string, password: string): Observable<any> {
    console.log(endpoint+"/login");
    let params = new HttpParams();
    params.append("email", email);
    params.append("password", password);
    return this.http.post<any>(endpoint+'/login?email='+email+'&password='+password, 
    {"email": email, "password": password},{observe:"response"});
  }
  
}
