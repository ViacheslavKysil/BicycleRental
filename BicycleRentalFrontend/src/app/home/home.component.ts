import { Component, OnInit } from '@angular/core';
import { BicycleService } from '../http/bicycle.service';
import { Bicycle } from '../models/bicycle.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  bicycles: Bicycle[];
  bicyclesRented: Bicycle[];
  bicyclesAvailable: Number;
  total: number;

  constructor(private bicycleService: BicycleService) {}

  ngOnInit(): void {
    this.bicycleService
      .getAvailableBicycles()
      .subscribe((bicycles: Bicycle[]) => {
        console.log(bicycles);
        this.bicycles = bicycles;
        this.bicyclesAvailable = bicycles.length;
      });

    this.bicycleService.getRentedBicycles().subscribe((bicycles: Bicycle[]) => {
      console.log('rented', bicycles);
      this.bicyclesRented = bicycles;
      let priceArray = this.bicyclesRented.map((x) => +x.price);
      this.total = priceArray.reduce((a, b) => a + b, 0)
    });

    this.bicycleService.updatedBicycles.subscribe(() => {
      this.bicycleService
        .getAvailableBicycles()
        .subscribe((bicycles: Bicycle[]) => {
          this.bicycles = bicycles;
          this.bicyclesAvailable = bicycles.length;
        });
      this.bicycleService
        .getRentedBicycles()
        .subscribe((bicycles: Bicycle[]) => {
          this.bicyclesRented = bicycles;
          let priceArray = this.bicyclesRented.map((x) => +x.price);
          this.total = priceArray.reduce((a, b) => a + b, 0)
        });
    });
  }
}
