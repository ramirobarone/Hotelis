import { Injectable } from '@angular/core';
import { Room } from 'src/models/room';
import { Hotel } from '../../../../models/hotel';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor() { }

  //_rooms: Room[] = [
  //  { id: 1, name: "Habitacion 1", description: "3 personas", urlPictures: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png" },
  //  { id: 1, name: "Habitacion 2", description: "2 personas", urlPictures: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png" },
  //  { id: 1, name: "Habitacion 3", description: "4 personas", urlPictures: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png" }
  //];


  public getHotels(hotel:string): Hotel[] {

    let hoteles: Hotel[] = [];


    return hoteles;
  }
}
