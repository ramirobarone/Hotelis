import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/home/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CardRoomComponent } from './components/bookings/card-room/card-room.component';
import { SearchBarComponent } from './components/home/search-bar/search-bar.component';
import { CardHotelComponent } from './components/home/card-hotel/card-hotel.component';
import { FooterComponent } from './components/home/footer/footer.component';
import { ReservedComponent } from './components/reserved/reserved.component';
import { BodyPrincipalComponent } from './components/home/body-principal/body-principal.component';
import { PopupComponent } from './components/Shared/popup/popup.component';
import { LoginComponent } from './components/Account/login/login.component';
import { AccountCreateComponent } from './components/Account/account-create/account-create.component';
import { LogoutComponent } from './components/Account/logout/logout.component';
import { BookingsComponent } from './components/bookings/bookings/bookings.component';
import { ControlRoomComponent } from './components/Account/control-room/control-room.component';
import { BillingDataComponent } from './components/bookings/billing-data/billing-data.component';
import { CheckoutComponent } from './components/bookings/checkout/checkout.component';


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
    LoginComponent,
    AccountCreateComponent,
    LogoutComponent,
    BookingsComponent,
    ControlRoomComponent,
    BillingDataComponent
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
      { path: 'accountCreate', component: AccountCreateComponent, pathMatch: 'full' },
      { path: 'logout', component: LogoutComponent, pathMatch: 'full' },

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
