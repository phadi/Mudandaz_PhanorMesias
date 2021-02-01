import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { IngresoComponent } from './ingreso/ingreso.component';
import { MenuComponent } from './menu/menu.component';
import { AdminComponent } from './admin/admin.component';
import { MudanzaComponent } from './mudanza/mudanza.component';
import { AutenticacionService } from './services/autenticacion.service'
import { ListamenuComponent } from './listamenu/listamenu.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    IngresoComponent,
    MenuComponent,
    AdminComponent,
    MudanzaComponent,
    ListamenuComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,    
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'ingreso', component: IngresoComponent },
      { path: 'menu', component: MenuComponent },
      { path: 'admin', component: AdminComponent },
      { path: 'mudanza', component: MudanzaComponent },
    ])
  ],
  providers: [AutenticacionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
