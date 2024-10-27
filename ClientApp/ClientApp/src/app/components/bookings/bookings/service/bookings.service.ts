import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookingDto } from 'src/models/bookingDto';

@Injectable({
  providedIn: 'root'
})
export class BookingsService {

  constructor(private http: HttpClient) { }

  baseurl: string = 'https://localhost:7291/api/';

  createBooking(booking: BookingDto): Observable<BookingDto> {
    console.log(this.baseurl + 'Bookings/CreateBooking', booking);
    return this.http.post<BookingDto>(this.baseurl + 'Bookings/CreateBooking', booking);
  }
  getBookings(): Observable<BookingDto[]> {
    return this.http.get<BookingDto[]>(this.baseurl + 'Bookings/GetBookings');
  }
}
