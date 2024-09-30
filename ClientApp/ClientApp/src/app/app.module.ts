import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CardRoomComponent } from './components/card-room/card-room.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { CardHotelComponent } from './components/card-hotel/card-hotel.component';
import { FooterComponent } from './components/footer/footer.component';
import { ReservedComponent } from './components/reserved/reserved.component';
import { BodyPrincipalComponent } from './components/body-principal/body-principal.component';
import { PopupComponent } from './components/Shared/popup/popup.component';
import { CheckoutComponent } from './components/Checkout/checkout/checkout.component';
import { LoginComponent } from './components/Account/login/login.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CardRoomComponent,
    SearchBarComponent,
    CardHotelComponent,
    FooterComponent,
    ReservedComponent,
    BodyPrincipalComponent,
    PopupComponent,
    CheckoutComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'room/:id', component: CardRoomComponent, pathMatch: 'full' },
      { path: 'reserve/:id', component: ReservedComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent, pathMatch: 'full' },

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
