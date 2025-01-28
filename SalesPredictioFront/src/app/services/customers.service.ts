import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { appsettings } from '../settings/settings';

@Injectable({
  providedIn: 'root',
})
export class CustomersService {
  private readonly baseUrl: string = appsettings.apiUrl + '/Customers';

  private readonly http = inject(HttpClient);

  getPredictionSales(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/getSalesPrediction`);
  }
}
