import { AvialableRoomsService } from 'src/services/AvialableRooms/avialable-rooms.service';
import { RoomService } from '../../../services/room.service';
import { Component, Injectable, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Room } from 'src/models/room';
import { Cost } from 'src/models/Cost';
import { BookingDto } from 'src/models/bookingDto';
import { BookingsService } from 'src/services/Bookings/bookings.service';
import { Schedule } from 'src/models/Schedule';

@Component({
  selector: 'app-card-room',
  templateUrl: './card-room.component.html',
  styleUrls: ['./card-room.component.css']
})
export class CardRoomComponent {


  idHotel: string | undefined = '';
  name: string = "";
  description: string = "";
  path: string = '';
  bedNumbers: number = 0;
  selectedRoom: any;
  cost: Cost = { id: 0, idRoom: 0, costPerHour: 0, hour: 0 };
  _timesEntry: any;
  showRoomMessage: boolean = false;

  selectedDate: any;
  timeSelected: any;
  currenRoom: any;
  times: Schedule[] = [];
  disabledTime = true;
  disabledDate = true;
  btnBookingDisabled = true;
  _rooms: Room[] = [];
  _booking: BookingDto | undefined;
  showCheckout = false;

  constructor(private roomService: AvialableRoomsService, private route: ActivatedRoute, private serviceBooking: BookingsService) {
    this.idHotel = this.route.snapshot.paramMap.get('id')?.toString();
    this.getRoom(this.idHotel);
  }

  getRoom(idHotel: string | undefined): void {
    console.log('idHotel', idHotel);
    this.roomService.getRoom(idHotel).subscribe(res => {
      this._rooms = res;
      this.selectFirst();
    });
  }
  onChange() {
    this.fillRoomFinded(this.currenRoom)
  }

  selectFirst(): void {
    if (this._rooms.length > 0) {
      this.name = this._rooms[0].name;
      this.description = this._rooms[0].description;
      this.bedNumbers = this._rooms[0].bedNumbers;
      this.cost = this._rooms[0].cost;
      this.bedNumbers = this._rooms[0].bedNumbers;
      this.bedNumbers = this._rooms[0].bedNumbers;
      this.path = this._rooms[0].roomPictures[0].path;
    }

  }
  changeDate(): void {
    this.disabledTime = this.selectedDate !== undefined;

    this.disabledTime = false;
    this.getTimesFree();
  }
  getTimesFree(): void {
    if (this.selectedDate === undefined || this.selectedRoom === undefined)
      return;

    this.roomService.getTimesFree(this.selectedRoom.id, this.selectedDate).subscribe(res => {

      console.log(res);
      this.times = res;
      this.showRoomMessage = this.times.length == 0;
      this.disabledTime = this.times.length == 0;
    });
  }

  fillRoomFinded(id: number): void {
    for (let i = 0; i < this._rooms.length; i++) {
      if (this._rooms[i].id == id) {

        this.selectedRoom = this._rooms[i];
        this.name = this._rooms[i].name;
        this.description = this._rooms[i].description;
        this.bedNumbers = this._rooms[i].bedNumbers;
        this.cost = this._rooms[i].cost;
        this.bedNumbers = this._rooms[i].bedNumbers;

        this.disabledDate = false;

        this.path = this._rooms[i].roomPictures[0].path;

        this.getTimesFree();
      }
    }
  }
  SelectTime(): void {
    this.btnBookingDisabled = this.timeSelected === undefined || this.timeSelected === 0;
  }
  CreateBooking(): void {

    this.showCheckout = true;

    this.btnBookingDisabled = true;

    this._booking = {
      IdRoom: this.selectedRoom.id, Date: this.selectedDate, CheckInTimeId: this.timeSelected
    };

    this.serviceBooking.createBooking(this._booking).subscribe(res => {
      this.btnBookingDisabled = false;
    });
  }
  showModal(): void {
    const modalToggle = document.getElementById('toggleMyModal');

    console.log(modalToggle);

  }

}
