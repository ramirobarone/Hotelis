import { Injectable } from '@angular/core';
import { Hotel, Room } from 'src/models/room';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor() { }

  _rooms: Room[] = [
    { id: 1, name: "Habitacion 1", description: "3 personas", urlPictures: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png" },
    { id: 1, name: "Habitacion 2", description: "2 personas", urlPictures: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png" },
    { id: 1, name: "Habitacion 3", description: "4 personas", urlPictures: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png" }
  ];


  public getHotels(hotel:string): Hotel[] {

    let hoteles: Hotel[] = [];

    hoteles = [
      { name: 'Rosario', id: 1, meta: 'Rosario', rooms: this._rooms, image: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png"  },
      { name: 'Cordoba', id: 2, meta: 'Cordoba capital', rooms: this._rooms , image: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png"  },
      { name: 'Rio Cuarto', id:3, meta: 'Cordoba Rio Cuarto', rooms: this._rooms , image: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png"  },
      { name : 'Hotel Monaco', id : 4, meta: 'Cordoba Carlos Paz Ruta 20', rooms:this._rooms , image: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png"  },
      { name : ' Doma y Folklore', id : 5, meta: 'Cordoba Jesus Maria Ruta 9', rooms:this._rooms , image: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png"  },
      { name : 'Sheraton', id : 6, meta: 'Cordoba Ruta 36 La Dormida', rooms:this._rooms , image: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png"  },
      { name : 'Emperador', id : 7, meta: 'Codoba Ruta 5 Alta gracia', rooms:this._rooms , image: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png"  },
      { name : 'Holiday In', id : 8, meta: 'Cordoba Av Aeropuerto', rooms:this._rooms , image: "https://dosflorines.com.ar/wp-content/uploads/2020/07/contenedores-habitables.png"  }
    ]

    return hoteles;
  }
}
