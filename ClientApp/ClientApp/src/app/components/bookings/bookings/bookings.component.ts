import { Component } from '@angular/core';
import { BookingsService } from './service/bookings.service';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent {

constructor(private bookinsService: BookingsService){}

}
