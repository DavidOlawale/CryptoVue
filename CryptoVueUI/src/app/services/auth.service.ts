import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../environments/environment';
import { Observable, tap } from 'rxjs';
import { jwtDecode } from 'jwt-decode'

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private jwtToken: string | undefined;

  constructor(private http: HttpClient) {
   }

  login(email: string, password: string): Observable<any>{
    let url = `${environment.apiUrl}/auth/login`;

    return this.http.post<any>(url, {email, password}, { headers: { 'Content-Type': 'application/json'} } )
    .pipe(
      tap(res => {
        if (res && res.token) {
          this.setToken(res.token);
        }
      })
    );
  }

  private setToken(token: string) {
    localStorage.setItem('jwtToken', token);
  }

  private getToken(): string {
    return localStorage.getItem('jwtToken') ?? "";
  }

  public GetUser(): any {
    if(this.isLoggedIn()){
      return jwtDecode(this.getToken());
    }
    else{
      return null;
    }
  }

  public isLoggedIn(): boolean {
    if(this.getToken() != null){
      let tokenEpiryDate = new Date(jwtDecode(this.getToken()).exp! * 1000); // Convert from seconds to milliseconds
      return tokenEpiryDate > new Date();  
    }
    
    return false;
  }
 
}