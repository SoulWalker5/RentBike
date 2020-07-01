import { Component, OnInit } from '@angular/core';
import { BikeService } from '../shared/bike.service';
import { BikeTypeService } from '../shared/bike-type.service';
import { BikeType } from '../shared/bike-type.model';
import { Bike } from '../shared/bike.model';

@Component({
  selector: 'app-bike-free',
  templateUrl: './bike-free.component.html',
  styleUrls: []
})
export class BikeFreeComponent implements OnInit {
  formData: Bike

  bikeTypeList = [];

  public service;
  public bikeTypeService;

  constructor(service: BikeService, bikeTypeService: BikeTypeService) {
    this.service = service;
    this.bikeTypeService = bikeTypeService;
  }

  ngOnInit(): void {
    this.service.getFreeBikes();
    this.bikeTypeService.getBikeType().subscribe(res => this.bikeTypeList = res as BikeType[]);
  }

  getBikeTypeByFind(id: number) {
    return this.bikeTypeList.find(x => x.BikeTypeId === id);
  }

  onDelete(id: number) {
    this.service.deleteBike(id)
      .subscribe(
        res => {
          this.service.getRentedBikes();
          this.service.getFreeBikes();
        },
        err => {
          console.log(err)
        })
  }
  
  onRent(formData: Bike) {
    formData.RentStateId = 1;
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

}
