import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent {

  @Input() title = '';
  @Input() description = '';
  @Input() action: any;
  @Input() url = '';


  actionButton(): void {
    if (this.action != undefined)
      this.action();
  }



}
