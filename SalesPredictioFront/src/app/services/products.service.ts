import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { appsettings } from '../settings/settings';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private readonly baseUrl: string = appsettings.apiUrl + '/Products';

  private readonly http = inject(HttpClient);

  getProducts(): Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/getProducts`);
  }
}
