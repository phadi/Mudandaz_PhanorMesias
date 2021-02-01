import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Module, User, UserModules } from '../interfaces';

@Injectable({
  providedIn: 'root'
})
export class AutenticacionService {
  usr: Observable<User>;
  baseUrl: string;
  autenticateServicePath: string = 'api/UserAuthentication/GetUser';
  autorizateServicePath: string = 'api/UserAuthentication/GetModulesByUser';
  modylesByUserServicePath: string = 'api/UserAuthentication/GetModulesByUsers';

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public autenticacion(login: string, psw: string): Observable<User> {
    
    return this.http.get<User>(this.baseUrl + this.autenticateServicePath + '?login=' + login + '&psw=' + psw);
  }

  public autorizacion(userId: string): Observable<Module[]> {

    return this.http.get<Module[]>(this.baseUrl + this.autorizateServicePath + '?userId=' + userId );
  }

  public modulesByUser(userId: string): Observable<UserModules[]> {

    return this.http.get<UserModules[]>(this.baseUrl + this.modylesByUserServicePath);
  }
}
