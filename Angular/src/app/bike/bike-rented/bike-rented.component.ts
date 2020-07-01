import { Component, OnInit } from '@angular/core';
import { BikeService } from '../shared/bike.service';
import { Bike } from '../shared/bike.model';
import { BikeTypeService } from '../shared/bike-type.service';
import { BikeType } from '../shared/bike-type.model';

@Component({
  selector: 'app-bike-rented',
  templateUrl: './bike-rented.component.html',
  styleUrls: []
})
export class BikeRentedComponent implements OnInit {
  formData: Bike

  bikeTypeList = [];

  public service;
  public bikeTypeService;

  constructor(service: BikeService, bikeTypeService: BikeTypeService) {
    this.service = service;
    this.bikeTypeService = bikeTypeService;

  }

  ngOnInit(): void {
    this.service.getRentedBikes();
    this.bikeTypeService.getBikeType().subscribe(res => this.bikeTypeList = res as BikeType[]);
  }

  onFree(formData: Bike) {
    formData.RentStateId = 2;
    this.service.putBike(formData)
      .subscribe(
        res => {
          this.service.getRentedBikes();
          this.service.getFreeBikes();
        },
        err => {
          console.log(err)
        })
  }

  getBikeTypeByFind(id: number) {
    return this.bikeTypeList.find(x => x.BikeTypeId === id);
  }
}
