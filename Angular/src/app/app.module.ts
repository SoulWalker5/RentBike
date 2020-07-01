import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms"
import { HttpClientModule } from "@angular/common/http";


import { AppComponent } from './app.component';
import { BikeComponent } from './bike/bike/bike.component';
import { BikeRentedComponent } from './bike/bike-rented/bike-rented.component';
import { BikeFreeComponent } from './bike/bike-free/bike-free.component';
import { BikeService } from './bike/shared/bike.service';

@NgModule({
  declarations: [
    AppComponent,
    BikeComponent,
    BikeRentedComponent,
    BikeFreeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [BikeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
