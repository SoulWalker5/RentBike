import { Bike } from './bike.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BikeService {
  formData: Bike

  rentedBikes: Bike[];
  freeBikes: Bike[];

  constructor(private http: HttpClient) { }

  postBike(formData) {
    return this.http.post(environment.apiBaseURI + '/Bike', formData);
  }

  getRentedBikes() {
    this.http.get(environment.apiBaseURI + '/Bike/RentedBike')
      .toPromise().then(res => this.rentedBikes = res as Bike[]);
  }

  getFreeBikes() {
    this.http.get(environment.apiBaseURI + '/Bike/FreeBike')
      .toPromise().then(res => this.freeBikes = res as Bike[]);
    
  }

  putBike(formData: Bike) {
    return this.http.put(environment.apiBaseURI + '/Bike/' + formData.BikeId, formData);
  }

  deleteBike(id: number) {
    return this.http.delete(environment.apiBaseURI + '/Bike/' + id);
  }
}
