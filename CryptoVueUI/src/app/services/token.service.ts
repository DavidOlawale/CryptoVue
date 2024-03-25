import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor(private http: HttpClient) { }

  getTokenData(): Observable<any> {
    let url = `${environment.apiUrl}/supply/getsupply`;
    return this.http.get(url);
  }
}
