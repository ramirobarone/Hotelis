import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDto, UserLoginDto } from '../Models/userDto';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseurl: string = 'https://localhost:7291/api/auth/'
  constructor(private http: HttpClient) { }

  authenticat(userDto: UserDto): Observable<UserLoginDto> {
    return this.http.post<UserLoginDto>(this.baseurl + 'Authenticat', userDto);
  }
}
