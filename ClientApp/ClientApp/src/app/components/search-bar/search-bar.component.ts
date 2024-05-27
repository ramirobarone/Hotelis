import { Component, Output, EventEmitter } from '@angular/core';
import { Hotel } from 'src/models/room';
import { HomeService } from 'src/services/home.service';
import { RoomService } from 'src/services/room.service';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent {

  @Output() _hotelesEmitter = new EventEmitter<Hotel[]>();
  _hoteles: Hotel[] = [];
  currentString: string = '';

  constructor(private hotelService: HomeService) {
  }

  BuscarHotel(): void {

    if (this.currentString === '')
      return;

    this._hoteles = this.hotelService.getHotels(this.currentString);

    this._hotelesEmitter.emit(this._hoteles);
  }
}
