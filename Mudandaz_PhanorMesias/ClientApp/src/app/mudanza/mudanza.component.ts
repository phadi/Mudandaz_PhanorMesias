import { Component } from '@angular/core';
import { Module, TrazaEjecucion, TrazaEjecucionModel } from '../interfaces';
import { AutenticacionService } from '../services/autenticacion.service';
import { ViajesService } from '../services/viajes.service';

//import * as jsfeat from 'jsfeat';

//var js = require('././assets/js/personalizado.js');


@Component({
  selector: 'app-home',
  templateUrl: './mudanza.component.html',
})

export class MudanzaComponent {
  public logedUsr: string
  public modules: Module[];
  public executions: TrazaEjecucion[];
  public excutionModel: TrazaEjecucionModel;
  public optionVariable: boolean;
  //Crud
  public cedula: string;
  public observaciones: string;
  // archivos
  public input: string;
  public output: string;
  private arrayData: any[] = [];

  public claseProceso: string;
  public claseTraza: string;


  constructor(private autenticacion: AutenticacionService,
    private viajes: ViajesService)
  {
    
    //console.log(jsfeat);
    this.optionVariable = true;
    this.claseProceso = 'btn-primary';
    this.claseTraza = 'btn-default';
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

  public cambioEstilo(cambio: boolean) {
    this.optionVariable = cambio;
    if (cambio) {
      this.claseProceso = 'btn-primary';
      this.claseTraza = 'btn-default';
    } else {
      this.claseProceso = 'btn-default';
      this.claseTraza = 'btn-primary';

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
    var elemento = document.getElementById('contenidoInput');
    this.input = elemento.innerHTML;

    let messaje: string = '';

    if (this.cedula === "" || this.cedula === undefined || this.cedula === null) {
      messaje += 'El campo cedula no puede estar vacio \n';
    } 

    if (this.input === "" || this.input === undefined || this.input === null) {
      messaje += 'Seleccione archivo con los datos de entrada.';
    }

    if (messaje === '') {
      this.leerArchivo();    
    } else {
      alert(messaje);
    }
  }

  private leerArchivo() {
    try {      
      this.procesaInfo(this.input);

    } catch (error) {
      this.observaciones = error;
    } finally {
      this.saveExecution();
    }
  }
 
  private procesaInfo(texto: string) {
    this.arrayData = texto.split('\n');

    let textoSalida: string = '';
    let contadorArreglo: number = 1;

    let dias: number = +this.arrayData[0];

    for (let j = 1; j <= dias; j++) {
      let textoProc: string = 'Case #' + j + ': ';
      let paquetes: number = +this.arrayData[contadorArreglo];
      let finArreglo: number = contadorArreglo + paquetes;
      contadorArreglo++;
      let pesos: number[] = [];
      let inicioArreglo: number = contadorArreglo;
      
      for (let k = inicioArreglo; k <= finArreglo; k++) {
        //arma arreglo por día
        var y: number = +this.arrayData[k];
        pesos.push(y);
        contadorArreglo++;
      }

      let suma: number = this.calculaMinimo(pesos);

      textoSalida = textoSalida + textoProc + suma + '\n';
    }

    this.output = textoSalida;
    this.observaciones = 'Procesado';    
  }

  private calculaMinimo(pesos: number[]) {
      //procesa la info
      let resultado: number = 0;
      pesos.forEach(function (data) {
        resultado = resultado + data;
      });

    return resultado;
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
        
      },
      err => {
        console.log(err);
        alert(err);
      }
    );
  }

  public limpiaFormulario() {
    this.output = '';
    this.observaciones = '';
    this.cedula = '';

    var elemento = document.getElementById('contenidoInput');
    elemento.innerHTML = '';
  }
}
