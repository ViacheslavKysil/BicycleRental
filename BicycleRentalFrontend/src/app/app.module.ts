import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BicycleComponent } from './home/bicycle/bicycle.component';
import { RentComponent } from './home/rent/rent.component';
import { CreateRentComponent } from './home/create-rent/create-rent.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BicycleComponent,
    RentComponent,
    CreateRentComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
