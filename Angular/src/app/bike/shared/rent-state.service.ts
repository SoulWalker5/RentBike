import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../../environments/environment';
import { RentState } from './rent-state.model';


@Injectable({
  providedIn: 'root'
})
export class RentStateService {
  formData: RentState

  constructor(private http: HttpClient) { }

  getRentState() {
    return this.http.get(environment.apiBaseURI + '/RentState');
   }
}


