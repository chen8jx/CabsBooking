import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Place } from 'src/app/shared/models/place';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class PlaceService {

  constructor(private apiService: ApiService) { }

  getAllPlaces(): Observable<Place[]> {
    return this.apiService.getAll('Places');
  }
}
