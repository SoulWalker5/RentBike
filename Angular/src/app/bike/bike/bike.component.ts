import { Component, OnInit } from '@angular/core';
import { BikeService } from '../shared/bike.service';
import { BikeTypeService } from '../shared/bike-type.service';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-bike',
  templateUrl: './bike.component.html',
  styleUrls: []
})
export class BikeComponent implements OnInit {

  bikeForms: FormArray = this.fb.array([]);

  bikeTypeList = [];

  public service;
  public bikeTypeService;

  constructor(public fb: FormBuilder, service: BikeService, bikeTypeService: BikeTypeService) {
    this.service = service;
    this.bikeTypeService = bikeTypeService;
  }

  ngOnInit(): void {
    this.addBikeForm();
    this.bikeTypeService.getBikeType().subscribe(res => this.bikeTypeList = res as []);
  }

  addBikeForm() {
    this.bikeForms.push(this.fb.group({
      BikeId: [0],
      BikeName: ['', Validators.required],
      BikePrice: [, Validators.required],
      BikeTypeId: [0, Validators.min(1)],
      RentStateId: [2, Validators.min(1)],
    }));
  }

  recordSubmit(fb: FormGroup) {
    this.service.postBike(fb.value).subscribe(
      res => {
        this.service.getRentedBikes();
        this.service.getFreeBikes();
        fb.reset({ BikeId:0, BikeTypeId: 0, RentStateId: 2 });
      }
    )
  }
}
