import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { appsettings } from '../settings/settings';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  private readonly baseUrl: string = appsettings.apiUrl + '/Employees';

  private readonly http = inject(HttpClient);

  getEmployees(): Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/getEmployees`);
  }
}
