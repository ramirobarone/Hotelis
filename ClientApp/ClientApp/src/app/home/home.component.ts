import { HomeService } from 'src/services/home.service';
import { Room } from './../../models/room';
import { RoomService } from '../../services/room.service';
import { Component } from '@angular/core';
import { Hotel } from 'src/models/hotel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  _room: Room | null = null;
  _hoteles: Hotel[] = [];

  constructor(private roomService: RoomService, HomeService: HomeService) {
    console.log(roomService.getRooms()[0]);

    this._room = roomService.getRooms()[0];


    this._hoteles = HomeService.getHotels('');
  }
  loadHotels(_hotels:Hotel[] ){
    this._hoteles =_hotels;

    console.log(this._hoteles);
  }

}
