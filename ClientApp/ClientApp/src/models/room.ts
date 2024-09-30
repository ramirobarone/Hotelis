import { Time } from "@angular/common";
import { Cost } from "./Cost";
import {  roomPictures } from "./roomImages";

export class Room {
  id: number = 0;
  name: string = '';
  description: string = '';
  path: string = '';
  bedNumbers: number = 0;
  avialableNow: boolean = true;
  cost: Cost = { id: 0, idRoom: 0, costPerHour: 0, hour: 0 };
  roomPictures: roomPictures[] = [];
}


export interface Province {
  id: number;
  name: string;
}
export interface City {
  id: number;
  name: string;
  province: Province;
}
