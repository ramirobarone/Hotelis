import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {

  @Input() description = '';
  @Input() idRoom = 0;
  @Input() checkInTimeId = 0;
  @Input() date = '';


  disabledButtonPay = false;

  Checkout(): void {

    this.disabledButtonPay = true;

    //this.disabledButtonPay = true;
  }
}
