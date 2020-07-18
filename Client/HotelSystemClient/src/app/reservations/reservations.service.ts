import { IReservation } from './reservation';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class ReservationsService{
    constructor(private client: HttpClient) {
            
    }
    public getReservations() :Observable<Array<IReservation>>{
        return this.client.get<Array<IReservation>>('https://localhost:5001/Home/Index');
    }
}