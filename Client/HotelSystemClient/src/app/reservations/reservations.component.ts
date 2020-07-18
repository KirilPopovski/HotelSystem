import { ReservationsService } from './reservations.service';
import { Component, OnInit } from '@angular/core';
import { IReservation } from './reservation';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css']
})
export class ReservationsComponent implements OnInit {

  reservations: Array<IReservation>;

  constructor(private _service: ReservationsService) { 
    
  }

  ngOnInit(): void {
      this._service.getReservations()
    .subscribe(data => this.reservations = data['hotels']);
  }

  title = "Welcome to Hotel System!";
  

}
