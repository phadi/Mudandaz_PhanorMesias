import { Component, Input } from '@angular/core';
import { Module } from '../interfaces';
import { AutenticacionService } from '../services/autenticacion.service';

@Component({
  selector: 'app-listamenu',
  templateUrl: './listamenu.component.html',
})

export class ListamenuComponent {
  @Input() modules: Module[];
  public logedUsr: string

  constructor(private autenticacion: AutenticacionService) {
    this.logedUsr = localStorage.getItem('logedUser');
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
