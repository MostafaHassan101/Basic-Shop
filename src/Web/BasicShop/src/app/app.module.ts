import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppLayoutComponent } from './app-layout/app-layout.component';
import { AppMainNavigationComponent } from './app-layout/app-main-navigation/app-main-navigation.component';
import { AppContentComponent } from './app-layout/app-content/app-content.component';
import { DxFormComponent, DxListModule, DxPopupModule, DxScrollViewModule, DxTemplateModule } from 'devextreme-angular';
import { HomePageComponent } from './home-page/home-page.component';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DxTextBoxModule, DxButtonModule, DxDropDownButtonModule, DxFormModule, DxLoadIndicatorModule } from 'devextreme-angular';
import { ProductsModule } from './modules/products/products.module';
import * as $ from 'jquery';
import { CookieService } from 'ngx-cookie-service';
import { AuthInterceptorService } from './services/auth-interceptor.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { MatPaginatorModule } from '@angular/material/paginator';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LoadingSpinnerComponent } from './loading-spinner/loading-spinner.component';
import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { ProductsForUserComponent } from './modules/user/components/products-for-user/products-for-user.component';
import { CartComponent } from './modules/user/components/cart/cart.component';
import { Shop } from './modules/user/components/shop/shop.component';

@NgModule({
  declarations: [
    AppComponent,
    AppLayoutComponent,
    AppMainNavigationComponent,
    AppContentComponent,
    HomePageComponent,
    LoadingSpinnerComponent,
    ProductsForUserComponent,
    CartComponent,
    Shop,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    DxListModule,
    DxTemplateModule,
    DxTextBoxModule,
    DxButtonModule,
    DxDropDownButtonModule,
    DxLoadIndicatorModule,
    DxPopupModule,
    DxScrollViewModule,
    DxFormModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }

    }),
  ],
  providers: [CookieService,
    // {
    //   provide: HTTP_INTERCEPTORS,
    //   useClass: AuthInterceptorService,
    //   multi: true
    // }
    // {
    //   provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true
    // }
  ],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule {

}
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
