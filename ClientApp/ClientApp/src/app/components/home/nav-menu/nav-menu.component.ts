import { Component, Input, OnInit, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  userName: string | null = '';
  isExpanded = false;
  isLoged = false;

  ngOnInit(): void {
    window.addEventListener('refrescar', this.refreshUser);

    this.refreshUser();
  }
  constructor(private router: Router) {
  }
  refreshUser() {
    this.userName = localStorage.getItem('fullName');

    console.log('refreshUser', this.userName === null || this.userName === '' || this.userName === undefined);
    console.log('username', this.userName);
    if (this.userName === null || this.userName === '' || this.userName === undefined) {
      this.isLoged = false;
      this.userName = '';
      console.log('entre por el false');
    }
    else {
      this.isLoged = true;
    
    }
  }

  logout(): void {
    console.log('logout');
    dispatchEvent(new Event('refrescar'));
    localStorage.removeItem('token');
    localStorage.removeItem('fullName');
    this.router.navigate(['/']);
  }
  collapse() {
    this.isExpanded = false;
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
