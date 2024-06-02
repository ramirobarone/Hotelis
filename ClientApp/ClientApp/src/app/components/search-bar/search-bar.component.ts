import { Component, Output, EventEmitter } from '@angular/core';
import { Hotel } from 'src/models/hotel';
import { HotelService } from 'src/services/HotelService/hotel.service';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent {

  @Output() _hotelesEmitter = new EventEmitter<Hotel[]>();
  _hoteles: Hotel[] = [];
  currentString: string = '';

  constructor(private hotelService: HotelService) {
  }

  BuscarHotel(): void {

    if (this.currentString === '')
      return;
    console.log(this.currentString);

    this.hotelService.getHotels(this.currentString).subscribe(res => {
      console.log(res);

      // this._hoteles = res;
    });

    this._hotelesEmitter.emit(this._hoteles);
  }
}
