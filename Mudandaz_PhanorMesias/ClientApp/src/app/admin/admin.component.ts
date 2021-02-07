import { Component } from '@angular/core';
import { Module, UserModules, User, UserEdited} from '../interfaces';
import { AutenticacionService } from '../services/autenticacion.service';

@Component({
  selector: 'app-home',
  templateUrl: './admin.component.html',
})

export class AdminComponent {
  public logedUsr: string
  public modules: Module[];
  public moduleList: Module[];
  public userModules: UserModules[];
  public userModule: UserModules;
  public users: User[];
  //CRUD
  public name: string;
  public login: string;
  public password: string;
  public userId: number;

  public editNewUser: UserEdited;

  public esEditar: boolean = false;

  constructor(private autenticacion: AutenticacionService)
  {
    this.logedUsr = localStorage.getItem('logedUser');
    if (this.logedUsr != null) {

      this.autenticacion.modulesByUser(this.logedUsr).subscribe(
        data => {
          this.userModules = data;          
          let userModule  = data.filter(u => u.user.userId.toString() == this.logedUsr)
          this.userModule = userModule[0];
          this.modules = this.userModule.modules;
        },
        err => {
          console.log(err);
          alert(err);
        }
      );

      this.autenticacion.getModules().subscribe(
        data => {
          this.moduleList = data;
        },
        err => {
          console.log(err);
          alert(err);
        }
      );
    }
  }

  public editUser(userEdit: UserModules) {
    this.esEditar = true;
    this.name = userEdit.user.name;
    this.login = userEdit.user.login;
    this.password = userEdit.user.password;
    this.userId = userEdit.user.userId;

    this.moduleList.map(function (dato) {
      for (let dato1 of userEdit.modules) {
        if (dato1.moduleId == dato.moduleId) {
          dato.isSelected = true;
          break;
        } else {
          dato.isSelected = false;
        }
      }
      return dato;
    });    
  }

  public saveEditUser() {
    
    this.editNewUser = new UserEdited();

    this.editNewUser.UserId = this.userId;
    this.editNewUser.Name = this.name;
    this.editNewUser.Login = this.login;
    this.editNewUser.Password = this.password;

    this.autenticacion.saveUser(this.editNewUser, this.moduleList).subscribe(
      data => {
        let resp = data;
        if (resp.userId == -1) {
          alert(resp.name);
        } else {
          this.esEditar = false;
          location.reload();
        }
        
      },
      err => {
        console.log(err);
        alert(err);
      }
    );
  }

  public newUser() {
    this.esEditar = true;
    this.name = '';
    this.login = '';
    this.password = '';
    this.userId = 0;

    this.moduleList.map(function (dato) {
      dato.isSelected = false
      return dato;
    });
  }

  public cancelar() {
    this.esEditar = false;
  }
}
