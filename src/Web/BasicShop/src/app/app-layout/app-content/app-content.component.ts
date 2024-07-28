import { Component,HostListener } from '@angular/core';

@Component({
  selector: 'app-content',
  templateUrl: './app-content.component.html',
  styleUrls: ['./app-content.component.scss']
})
export class AppContentComponent {
  windowScrolled = false;
  isShow: boolean =false;
  topPosToStartShowing = 100;
  @HostListener('window:scroll')
  checkScroll() {
      const scrollPosition = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;
      if (scrollPosition >= this.topPosToStartShowing) {
          this.isShow = true;
      } else {
          this.isShow = false;
      }
  }
  gotoTop() {
      window.scroll({
          top: 0,
          left: 0,
          behavior: 'smooth'
      });
  }
}
