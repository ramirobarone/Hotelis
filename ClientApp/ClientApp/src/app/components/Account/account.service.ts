import { Injectable } from '@angular/core';
import { EnvironmentsService } from '../../ServicesShared/environments.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { UserCreateDto } from './Models/accountDto';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private _environment: EnvironmentsService, private http: HttpClient) { }

  createAccount(account:UserCreateDto): Observable<boolean> {

    console.log('urlbase', this._environment.getUrlBase() + 'Auth/CreateAccount');
    return this.http.post<boolean>(this._environment.getUrlBase() + 'Auth/CreateAccount', account);
  }


}
