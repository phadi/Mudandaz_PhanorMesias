import { Component } from '@angular/core';
import { AutenticacionService } from '../services/autenticacion.service';
import { User } from '../interfaces';

@Component({
  selector: 'app-home',
  templateUrl: './ingreso.component.html',
})

export class IngresoComponent {
  public user;
  public password;
  public resp: User;
  public logedUsr: string

  constructor(private autenticacion: AutenticacionService) {
    this.logedUsr = localStorage.getItem('logedUser');
  }

  public login() {
    
    this.autenticacion.autenticacion(this.user, this.password).subscribe(
      data => {
        this.resp = data;
        if (this.resp.userId == 0) {
          localStorage.clear();
          alert('usuario o contraseña invalido.');
        } else {
          localStorage.setItem('logedUser', this.resp.userId.toString());
          location.replace('/menu');
        }        
      },
      err => {
        console.log(err);
        alert(err);
      }
    );    
  }

  public logout() {
    localStorage.clear();
    location.replace('/');
  }
}
