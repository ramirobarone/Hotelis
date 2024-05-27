import { Time } from "@angular/common";


export interface Hotel {
  id: number;
  name: string;
  image: string;
  rooms: Room[];
  // address: Address;
  meta: string;
}

export class Room {
  id: number = 0;
  name: string = '';
  description: string = '';
  urlPictures: string = '';
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
export interface Address {
  id: number;
  address: string;
  number: number;
  city: City;
  phone: string;
  codeArea: string;
}

export interface ReserveRoom {
  idRoom: number;
  idCost: number;
  dateEntry: Date;
  hourStart: Time;
  hourEnd: Time;
  idUser: string;
}
export interface CostPerRoom {
  id: number;
  idRoom: number;
  hours: number;
  value: number;
}
