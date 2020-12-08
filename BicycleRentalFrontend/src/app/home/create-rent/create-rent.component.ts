import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BicycleService } from 'src/app/http/bicycle.service';

@Component({
  selector: 'app-create-rent',
  templateUrl: './create-rent.component.html',
  styleUrls: ['./create-rent.component.css'],
})
export class CreateRentComponent implements OnInit {
  bikeTypeStates;

  bicycleForm = new FormGroup({
    bikeName: new FormControl('', [Validators.required]),
    bikeType: new FormControl(''),
    price: new FormControl('', [Validators.required]),
  });

  constructor(private bicycleService: BicycleService) {}

  ngOnInit(): void {
    this.bicycleService.getBicycleTypes()
      .subscribe((bicycleTypes) => {
        this.bikeTypeStates = bicycleTypes;
      })
  }

  onSubmit() {
    console.log('onSubmit')
    let bikeName = this.bicycleForm.get('bikeName').value
    let bikeType = this.bicycleForm.get('bikeType').value.toLowerCase()
    let price = this.bicycleForm.get('price').value
    
    this.bicycleService
      .createRent({
        Name: bikeName,
        Price: price,
        RentalType: bikeType,
      })
      .subscribe((response) => {
        this.bicycleService.updatedBicycles.next();
        console.log('Hi', response);
      });
  }
}
