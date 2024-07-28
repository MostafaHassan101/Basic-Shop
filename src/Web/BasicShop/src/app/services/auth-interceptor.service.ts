import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable, tap } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class AuthInterceptorService {
//implements HttpInterceptor {

	constructor(private cookieService: CookieService) { }

	// intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
	// 	const token = this.cookieService.get('token');
	// 	console.log('token', token);
	// 	console.log('request', request);
	// 	if (!token) {
	// 		console.log('No token');
	// 		return next.handle(request);
	// 	}
		// request.headers = request.headers.Append('Authorization', `Bearer ${token}`),
		// const modifiedRequest = request.clone({
		// setHeaders: {
		// 	AuthorizationTest: `Bearer ${token}`,
		// }
		// });
		//  return next.handle(modifiedRequest).pipe(
		//  	tap((event: HttpEvent<any>) => {
		//  		// console.log('Incoming HTTP response', event);
		//  	})
		//  );
	// }
}
