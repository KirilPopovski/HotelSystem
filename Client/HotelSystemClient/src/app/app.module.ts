import { ReservationsService } from './reservations/reservations.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ReservationsComponent } from './reservations/reservations.component';
import {HttpClientModule} from '@angular/common/http'

@NgModule({
  declarations: [
    AppComponent,
    ReservationsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    ReservationsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
