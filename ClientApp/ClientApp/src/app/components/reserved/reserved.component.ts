import { Room } from 'src/models/room';
import { RoomService } from 'src/services/room.service';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-reserved',
  templateUrl: './reserved.component.html',
  styleUrls: ['./reserved.component.css']
})
export class ReservedComponent {


  currentRoom: number = 0;
  dateSelected: Date = new Date();
  idHour: number = 0;
  cost: number = 0;

  selectedRoom: Room  = new Room();

  constructor(private roomService: RoomService) {

  }


  getRoomSelected(): void {
     this.selectedRoom = this.roomService.getCurrentRoom();


  }

  getHoursAvailable(): void {

  }
  getCost(idRoom: number): void {

  }
  nextToPay(): void {

  }

}
