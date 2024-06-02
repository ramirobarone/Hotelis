import {  Room } from '../models/room';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor() { }

  currentRoom: Room = { id: 1, name: "Demo 1", description: "3 personas", urlPictures: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png" };


  public getRooms(): Room[] {

    let rooms: Room[] = [
      { id: 1, name: "Habitacion 1", description: "3 personas", urlPictures: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png" },
      { id: 1, name: "Habitacion 2", description: "2 personas", urlPictures: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png" },
      { id: 1, name: "Habitacion 3", description: "4 personas", urlPictures: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png" }
    ];

    return rooms;

  }
  public getCurrentRoom(): Room {
    return this.currentRoom;

  }
  public setCurrentRoom(room: Room): void {
    this.currentRoom = room;
  }
}
