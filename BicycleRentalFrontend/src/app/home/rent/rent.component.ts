import { Component, Input, OnInit } from '@angular/core';
import { BicycleService } from 'src/app/http/bicycle.service';

@Component({
  selector: 'app-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.css']
})
export class RentComponent implements OnInit {
  @Input() id: string;
  @Input() name: string;
  @Input() rentalType: string;
  @Input() price: number;

  constructor(private bicycleService: BicycleService) { }

  ngOnInit(): void {
  }

  cancelRent() {
    this.bicycleService.cancelRent(this.id).subscribe(() => {
      this.bicycleService.updatedBicycles.next();
    })
  }

}
