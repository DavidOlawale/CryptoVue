import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor(private http: HttpClient, private authService: AuthService) { }

  getTokenData(): Observable<any> {
    let url = `${environment.apiUrl}/supply/getsupply`;
    return this.http.get(url);
  }

  updateTokenData(){
    var token = localStorage.getItem('jwtToken');
    let url = `${environment.apiUrl}/supply/updatesupply`;
    return this.http.post(url, null, { headers: {'Authorization': `Bearer ${token}`}});
  }
}
