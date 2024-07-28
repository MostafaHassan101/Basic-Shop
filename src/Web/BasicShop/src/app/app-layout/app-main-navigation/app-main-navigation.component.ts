import { Component } from '@angular/core';
import { NgbDatepickerModule, NgbOffcanvas, OffcanvasDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-main-navigation',
  templateUrl: './app-main-navigation.component.html',
  styleUrls: ['./app-main-navigation.component.scss']
})
export class AppMainNavigationComponent {

	closeResult = '';

constructor(private offcanvasService: NgbOffcanvas) {}

open(content:any) {
  this.offcanvasService.open(content, { ariaLabelledBy: 'offcanvas-basic-title' }).result.then(
    (result) => {
      this.closeResult = `Closed with: ${result}`;
    },
  
  );
}
}
