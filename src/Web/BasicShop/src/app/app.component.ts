import { Component } from '@angular/core';
import {NgbConfig} from '@ng-bootstrap/ng-bootstrap';
import {TranslateService} from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  
  

  constructor(public tanslateService:TranslateService){
    // const userLang= navigator.language || 'en';
    // const languageCode =userLang.split('-')[0];
    // this.ttanslateService.setDefaultLang(languageCode);
    // this.ttanslateService.use(languageCode);
    tanslateService.addLangs(['de','NL']);
    tanslateService.setDefaultLang('NL')
  }
  switchLang(lang:string){
    this.tanslateService.use(lang);
  }

  title = 'BasicShopUI';
}
