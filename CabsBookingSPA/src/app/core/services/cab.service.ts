import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cab } from 'src/app/shared/models/cab';
import { CabBookings } from 'src/app/shared/models/cab-bookings';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CabService {

  constructor(private apiService: ApiService) { }

  getAllCabs(): Observable<Cab[]> {
    return this.apiService.getAll('CabTypes');
  }

  listBookings(cabId:number):Observable<CabBookings>{
    return this.apiService.getOne('CabTypes',cabId);
  }
}
