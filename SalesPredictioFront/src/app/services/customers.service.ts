import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { appsettings } from '../settings/settings';

@Injectable({
  providedIn: 'root',
})
export class CustomersService {
  private readonly baseUrl: string = appsettings.apiUrl + '/Customers';

  private readonly http = inject(HttpClient);

  getPredictionSales(searchCompany?: string): Observable<any> {
    const params = new HttpParams().set('searchCompany', searchCompany ?? '');
    return this.http.get<any>(`${this.baseUrl}/getSalesPrediction`,{params});
  }
}
