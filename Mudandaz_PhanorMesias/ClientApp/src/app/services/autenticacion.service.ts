import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Module, User, UserModules, UserEdited } from '../interfaces';

@Injectable({
  providedIn: 'root'
})
export class AutenticacionService {
  baseUrl: string;
  servicePath: string = 'api/UserAuthentication/';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public autenticacion(login: string, psw: string): Observable<User> {
    
    return this.http.get<User>(this.baseUrl + this.servicePath + 'GetUser?login=' + login + '&psw=' + psw);
  }

  public autorizacion(userId: string): Observable<Module[]> {

    return this.http.get<Module[]>(this.baseUrl + this.servicePath + 'GetModulesByUser?userId=' + userId );
  }

  public modulesByUser(userId: string): Observable<UserModules[]> {

    return this.http.get<UserModules[]>(this.baseUrl + this.servicePath + 'GetModulesByUsers');
  }

  public saveUser(userEdited: UserEdited, moduleList: Module[]): Observable<User> {

    return this.http.post<User>(this.baseUrl + this.servicePath + 'saveUser?tbUserModel=' + JSON.stringify(userEdited) + '&tbModuleModels=' + JSON.stringify(moduleList), JSON.stringify(userEdited), this.httpOptions);
  }

  public getModules(): Observable<Module[]> {

    return this.http.get<Module[]>(this.baseUrl + this.servicePath + 'GetModules');
  }
}
