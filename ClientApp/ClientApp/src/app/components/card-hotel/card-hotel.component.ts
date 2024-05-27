import { RoomService } from 'src/services/room.service';
import { Component, Input } from '@angular/core';
import { Room } from 'src/models/room';

@Component({
  selector: 'app-card-hotel',
  templateUrl: './card-hotel.component.html',
  styleUrls: ['./card-hotel.component.css']
})
export class CardHotelComponent {

  @Input()
  name: string = '';
  @Input()
  description: string = ''
  @Input()
  image: string = ''
  @Input()
  address: string = '';
  @Input()
  availableRooms: number = 0;
  @Input()
  stateHotel: boolean = true;
  @Input()
  idRoom: string = '';

  constructor(private RoomService: RoomService) {

  }

  setCurrentRoom(): void {

    let id = Number.parseInt(this.idRoom)

    let currentRoom = { id: id, name: this.name, description: this.description, urlPictures: "" }

    this.RoomService.setCurrentRoom(currentRoom)
  }

}
