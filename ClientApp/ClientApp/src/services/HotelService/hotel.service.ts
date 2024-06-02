import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Hotel } from 'src/models/hotel';

@Injectable({
  providedIn: 'root'
})
export class HotelService {

  constructor(private http: HttpClient) {

  }
  baseurl: string = 'https://localhost:7291/api/hotel/'

  getHotels(keyword: string): Observable<Hotel> {
    return this.http.get<Hotel>(this.baseurl + 'getHotels?searchKey=' + keyword);
  }
}
