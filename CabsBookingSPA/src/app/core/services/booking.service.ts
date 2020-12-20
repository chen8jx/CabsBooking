import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Booking } from 'src/app/shared/models/booking';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private apiService: ApiService) { }

  getAllBookings(): Observable<Booking[]> {
    return this.apiService.getAll('Bookings');
  }
}
