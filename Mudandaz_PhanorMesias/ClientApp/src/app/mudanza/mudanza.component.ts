import { Component } from '@angular/core';
import { Module, TrazaEjecucion, TrazaEjecucionModel } from '../interfaces';
import { AutenticacionService } from '../services/autenticacion.service';
import { ViajesService } from '../services/viajes.service';

import { HttpClient } from '@angular/common/http'; 


@Component({
  selector: 'app-home',
  templateUrl: './mudanza.component.html',
})

export class MudanzaComponent {
  public logedUsr: string
  public modules: Module[];
  public executions: TrazaEjecucion[];
  public excutionModel: TrazaEjecucionModel;
  //Crud
  public cedula: string;
  public observaciones: string;

  constructor(private autenticacion: AutenticacionService,
    private viajes: ViajesService,
    private http: HttpClient)
  {
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

      this.viajes.getTraceExecutions().subscribe(
        data => {

          this.executions = data;
        },
        err => {
          console.log(err);
          alert(err);
        }
      );

    }
  }

  public ejecutar() {
    if (this.cedula === "" || this.cedula === undefined || this.cedula === null)   {
      alert('El campo cedula no puede estar vacio');
    } else {
      this.leerArchivo();
      this.saveExecution();      
    }
    
  }

  private saveExecution() {
    this.excutionModel = new TrazaEjecucionModel();

    this.excutionModel.DateTime = new Date();
    this.excutionModel.EjecutorId = this.cedula;
    this.excutionModel.Observations = this.observaciones;
    this.excutionModel.UserId = +this.logedUsr;

    this.viajes.saveTrace(this.excutionModel).subscribe(
      data => {

        this.excutionModel = data;
        location.reload();
      },
      err => {
        console.log(err);
        alert(err);
      }
    );

  }

  private leerArchivo() {
    
  }
}
