/// <reference types="@angular/localize" />

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { bootstrapApplication } from '@angular/platform-browser';
import { importProvidersFrom } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AuthInterceptorService } from './app/services/auth-interceptor.service';
import { AppComponent } from './app/app.component';


platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));

// bootstrapApplication(AppComponent, {
//   providers: [
//     importProvidersFrom(HttpClientModule),
//     AuthInterceptorService,
//   ]
// });