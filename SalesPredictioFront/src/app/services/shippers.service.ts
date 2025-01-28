import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { appsettings } from '../settings/settings';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShippersService {

  private readonly baseUrl: string = appsettings.apiUrl + '/Shippers';

  private readonly http = inject(HttpClient);

  getShippers(): Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/getShippers`);
  }
}
