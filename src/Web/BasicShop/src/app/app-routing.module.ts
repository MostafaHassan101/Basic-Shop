import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HomePageComponent } from './home-page/home-page.component';
import { AuthGuardService } from './services/auth-guard.service';
import { ProductsListComponent } from './modules/products/components/products-list/products-list.component';
import { Shop } from './modules/user/components/shop/shop.component';
const routes: Routes = [];

const appRoute: Routes = [
  {
    path: '',
    component: HomePageComponent,
    pathMatch: 'full',
  },
  {
    path: 'product',
    component: ProductsListComponent,
  },
  {
    path: 'shop-n-cart',
    component: Shop
  },
  {
    path: '**',
    redirectTo: '',
  }
];


@NgModule({
  imports: [BrowserModule, RouterModule.forRoot(appRoute), FormsModule],

  exports: [RouterModule],
})
export class AppRoutingModule { }
