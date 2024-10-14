import { Component, ElementRef, EventEmitter, Output, Renderer2, ViewChild } from '@angular/core';
import { UserDto, UserLoginDto } from './Models/userDto';
import { AccountService } from './Service/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  @ViewChild('fullNameLabel') fullNameChild!: ElementRef;

  constructor(private serviceAuthenticat: AccountService, private router: Router, private renderer: Renderer2) {
  }
  userDto: UserDto = { email: 'ramiro_barone@hotmail.com', password: 'ramiro0908' };

  login(): void {
    this.serviceAuthenticat.authenticat(this.userDto).subscribe({
      next: (res) => {
        console.log('token:', res);
        localStorage.setItem('token', res.token);
        localStorage.setItem('fullName', res.fullName);
        this.changeFullName(res.fullName);
        this.router.navigate(['/']);
        dispatchEvent(new Event('refrescar'));
      },
      error: (err) => {
        console.error('Error authenticating', err);
      }
    });
  }
  changeFullName(name: string): void {
 
  }
}