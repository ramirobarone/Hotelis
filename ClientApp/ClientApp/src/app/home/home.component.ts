import { HomeService } from 'src/services/home.service';
import { Room } from './../../models/room';
import { RoomService } from '../../services/room.service';
import { Component } from '@angular/core';
import { Hotel } from 'src/models/hotel';
import { GoogleMap } from '@angular/google-maps';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  fullName = '';
  _room: Room | null = null;
  _hoteles: Hotel[] = [];
  isBodyVisible: boolean = true;

  constructor(private roomService: RoomService, HomeService: HomeService) {

  }
  loadHotels(_hotels: Hotel[]) {
    this._hoteles = _hotels;
    if (this._hoteles.length > 0)
      this.isBodyVisible = false;

    console.log(this._hoteles);
  }
}
