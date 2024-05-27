import { RoomService } from '../../../services/room.service';
import { Component, Injectable, Input } from '@angular/core';

@Component({
  selector: 'app-card-room',
  templateUrl: './card-room.component.html',
  styleUrls: ['./card-room.component.css']
})
export class CardRoomComponent {

  @Input() name: string = "";
  @Input() description: string = "";
  @Input() urlImage: string = "";
  constructor() {

  }




}
