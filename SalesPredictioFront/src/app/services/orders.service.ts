import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { appsettings } from '../settings/settings';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  private readonly baseUrl: string = appsettings.apiUrl + '/Orders';

  private readonly http = inject(HttpClient);

  getOrders(customerId: string): Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/getOrders/${customerId}`);
  }

  addNewOrder(formValue: any): Observable<any>{
    return this.http.post<any>(`${this.baseUrl}/addOrder`, formValue);
  }
}
