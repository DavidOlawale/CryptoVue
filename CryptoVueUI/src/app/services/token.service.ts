import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { DashboardDTO, UnlockScheduleDTO, VestingScheduleDTO } from '../shared/AppModels';

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

  getDashboardData(): Promise<DashboardDTO>{
    var token = localStorage.getItem('jwtToken');
    let url = `${environment.apiUrl}/supply/dasboard`;
    return this.http.get<DashboardDTO>(url, { headers: {'Authorization': `Bearer ${token}`}}).toPromise();
  }

  getVestingSchedule(): Promise<VestingScheduleDTO[]>{
    var token = localStorage.getItem('jwtToken');
    let url = `${environment.apiUrl}/supply/vestingschedule`;
    return this.http.get<VestingScheduleDTO[]>(url, { headers: {'Authorization': `Bearer ${token}`}}).toPromise();
  }

  getUnlockSchedule(): Promise<UnlockScheduleDTO[]>{
    var token = localStorage.getItem('jwtToken');
    let url = `${environment.apiUrl}/supply/unlockschedule`;
    return this.http.get<UnlockScheduleDTO[]>(url, { headers: {'Authorization': `Bearer ${token}`}}).toPromise();
  }
}
