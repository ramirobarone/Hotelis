import { HttpClient } from '@angular/common/http';
import {  Room } from '../models/room';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor(private http: HttpClient) { }

  baseurl: string = 'https://localhost:7291/api/'

  public getRooms(id: number): Observable<Room[]> {
    return this.http.get<Room[]>(this.baseurl + 'Room/getroombyid?idHotel='+id)
  }
}
