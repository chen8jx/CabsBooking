import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {

  constructor(private apiService: ApiService) { }

  getAllHistory(): Observable<History[]> {
    return this.apiService.getAll('BookingsHistory');
  }
}
