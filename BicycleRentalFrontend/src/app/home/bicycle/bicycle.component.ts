import { Component, Input, OnInit } from '@angular/core';
import { BicycleService } from 'src/app/http/bicycle.service';

@Component({
  selector: 'app-bicycle',
  templateUrl: './bicycle.component.html',
  styleUrls: ['./bicycle.component.css']
})
export class BicycleComponent implements OnInit {
  @Input() id: string;
  @Input() name: string;
  @Input() rentalType: string;
  @Input() price: number;

  constructor(private bicycleService: BicycleService) { }

  ngOnInit(): void {
  }

  rent() {
    this.bicycleService.rent(this.id).subscribe(() => {
      console.log('rent')
      this.bicycleService.updatedBicycles.next();
    })
  }

  deleteRent() {
    this.bicycleService.deleteRent(this.id).subscribe(() => {
      this.bicycleService.updatedBicycles.next();
    })
  }
}
