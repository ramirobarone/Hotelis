import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDto } from '../Models/userDto';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseurl: string = 'https://localhost:7291/api/auth/'
  constructor(private http: HttpClient) { }

  authenticat(userDto: UserDto): Observable<string> {

    return this.http.post<string>(this.baseurl + 'Authenticat', userDto);
  }
}
