import { Component } from '@angular/core';

import { Module } from '../interfaces';
import { AutenticacionService } from '../services/autenticacion.service';

@Component({
  selector: 'app-home',
  templateUrl: './menu.component.html',
})

export class MenuComponent {
  public logedUsr: string
  public modules: Module[];

  constructor(private autenticacion: AutenticacionService) {
    this.logedUsr = localStorage.getItem('logedUser');
    if (this.logedUsr != null) {

      this.autenticacion.autorizacion(this.logedUsr).subscribe(
        data => {

          this.modules = data;
        },
        err => {
          console.log(err);
          alert(err);
        }
      );    
    }
  }

  public navigation(path) {

    location.replace(path);
  }

  public salir() {
    localStorage.clear();
    location.replace('/');
  }

  public login() {
    location.replace('/ingreso');
  }
}
