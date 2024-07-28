import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { DxDataGridModule, DxNumberBoxModule, DxButtonModule, DxDropDownButtonModule, DxSelectBoxComponent } from 'devextreme-angular';
import { TranslateModule } from '@ngx-translate/core';
import { DxSelectBoxModule } from 'devextreme-angular';

@NgModule({
  declarations: [
    // ShoppingCartComponent
  ],
  imports: [
    CommonModule,
      UserRoutingModule,
      DxDataGridModule,
      DxNumberBoxModule,
      DxButtonModule,
      DxDropDownButtonModule,
      TranslateModule,
      DxSelectBoxModule
  ]
})
export class UserModule { }
