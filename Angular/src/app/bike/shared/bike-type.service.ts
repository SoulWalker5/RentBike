import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BikeTypeService {

  constructor(private http: HttpClient) { }

  getBikeType() {
    return this.http.get(environment.apiBaseURI + '/BikeType');
   }
}
