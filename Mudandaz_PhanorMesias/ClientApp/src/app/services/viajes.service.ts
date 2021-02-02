import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TrazaEjecucion, TrazaEjecucionModel } from '../interfaces';

@Injectable({
  providedIn: 'root'
})
export class ViajesService {
  baseUrl: string;
  servicePath: string = 'api/Mudanza/';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public getTraceExecutions(): Observable<TrazaEjecucion[]> {

    return this.http.get<TrazaEjecucion[]>(this.baseUrl + this.servicePath + 'GetTraceExecutions');
  }

  public saveTrace(trazaEjecucion: TrazaEjecucionModel): Observable<any> {

    return this.http.post<any>(this.baseUrl + this.servicePath + 'saveTrace?tbTrazaEjecucionModel=' + JSON.stringify(trazaEjecucion), JSON.stringify(trazaEjecucion), this.httpOptions);
  }

}
