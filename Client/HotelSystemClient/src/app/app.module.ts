import { UserService } from './user.service';
import { ReservationsService } from './reservations/reservations.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ReservationsComponent } from './reservations/reservations.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms'
import { RegisterComponent } from './register/register.component'

@NgModule({
  declarations: [
    AppComponent,
    ReservationsComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    ReservationsService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
