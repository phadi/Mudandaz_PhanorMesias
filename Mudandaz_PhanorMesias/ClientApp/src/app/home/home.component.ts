import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public logedUsr: string
  constructor() {
    this.logedUsr = localStorage.getItem('logedUser');
  }

  public logout() {
    localStorage.clear();
    location.replace('/');
  }
}
