import { Input, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from '././products-routing.module';
import { DxButtonModule, DxNumberBoxModule, DxListModule, DxDropDownButtonModule, DxLookupModule, DxDropDownBoxModule, DxSelectBoxModule, DxDataGridModule, DxSwitchModule } from 'devextreme-angular';
import { ProductsListComponent } from './components/products-list/products-list.component';
import dxDropDownBox from 'devextreme/ui/drop_down_box';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslateModule } from '@ngx-translate/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../../app-routing.module';


@NgModule({
  declarations: [
    ProductsListComponent
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    DxButtonModule,
    DxDataGridModule,
    DxSwitchModule,
    DxNumberBoxModule,
    DxListModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserModule,
    DxDropDownButtonModule,
    DxDropDownBoxModule,
    DxSelectBoxModule,
    DxLookupModule,
    NgxPaginationModule,
    NgbModule,
    TranslateModule,
  ],
  exports:[
  ]
})
export class ProductsModule { }
