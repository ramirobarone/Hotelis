import { HttpClient } from '@angular/common/http';
import {  Room } from '../models/room';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EnvironmentsService } from '../app/ServicesShared/environments.service';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor(private http: HttpClient, private serviceEnvironment: EnvironmentsService) { }

  baseurl: string = this.serviceEnvironment.getUrlBase();

  public getRooms(id: number): Observable<Room[]> {
    return this.http.get<Room[]>(this.baseurl + 'Room/getroombyid?idHotel='+id)
  }
}
