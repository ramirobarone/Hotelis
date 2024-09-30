import { Component } from '@angular/core';
import { UserDto } from './Models/userDto';
import { AccountService } from './Service/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private serviceAuthenticat: AccountService) {
    //this.userDto = { email: '', password: '' }
  }

  userDto: UserDto = { email: '', password: '' };
  login(): void {
    console.log(this.userDto);

    this.serviceAuthenticat.authenticat(this.userDto).subscribe(res => {

    });

  }

}
