import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { CreateRentComponent } from '../home/create-rent/create-rent.component';
import { Bicycle } from '../models/bicycle.model';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class BicycleService {
  bicycle: Bicycle[];
  updatedBicycles = new Subject();

  constructor(private httpService: HttpService) { 
  }

  getAvailableBicycles() {
    return this.httpService.get("bicycles/available");
  }

  getRentedBicycles() {
    return this.httpService.get("bicycles/rented");
  }

  getBicycleTypes() {
    return this.httpService.get("typeBicycles");
  }

  createRent(payload: Object) {
    return this.httpService.post("bicycle/new", payload);
  }

  cancelRent(id: string) {
    return this.httpService.post(`bicycle/cancelRent/${id}`);
  }

  rent(id: string) {
    return this.httpService.post(`bicycle/rent/${id}`);
  }

  deleteRent(id: string) {
    return this.httpService.delete(`bicycle/remove/${id}`);
  }
}
