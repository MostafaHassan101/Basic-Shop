import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import * as AspNetData from 'devextreme-aspnet-data'
import { DxParams } from '../models/dx-params';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { IHttpOptions } from '../models/ihttp-options';
import { CookieService } from 'ngx-cookie-service';

const BaseApiUrl = environment.ApiUrl.endsWith('/') ? environment.ApiUrl : environment.ApiUrl + '/';
@Injectable({
	providedIn: 'root'
})
export class ApiClientService {

	private refreshSubject = new Subject<void>();

	constructor(private http: HttpClient, private cookieService: CookieService) { }

	get<T>(url: string, options?: IHttpOptions): Observable<T> {
		return this.http
			.get<T>(BaseApiUrl + url, this.parseOptions(options));
	}

	post<T>(
		url: string,
		body?: any | null,
		options?: IHttpOptions
	): Observable<T> {
		return this.http
			.post<T>(BaseApiUrl + url, body, this.parseOptions(options));
	}

	put<T>(url: string, body?: any | null, options?: IHttpOptions): Observable<T> {
		return this.http
			.put<T>(BaseApiUrl + url, body, this.parseOptions(options));
	}

	delete<T>(url: string, options?: IHttpOptions): Observable<T> {
		return this.http
			.delete<T>(BaseApiUrl + url, this.parseOptions(options));
	}

	createDxStore(options: DxParams): any {
		function buildUrl(baseUrl: string, baseRoute: string, customRoute?: string): string {
			return baseUrl + (customRoute ? customRoute : baseRoute);
		}

		return AspNetData.createStore({
			key: options.key,
			loadUrl: buildUrl(BaseApiUrl, options.url),
			insertUrl: buildUrl(BaseApiUrl, options.url, options.insertUrl),
			updateUrl: buildUrl(BaseApiUrl, options.url, options.updateUrl),
			deleteUrl: buildUrl(BaseApiUrl, options.url, options.deleteUrl),
			cacheRawData: options.cacheRawData,

			onBeforeSend: (operation, ajaxOptions) => {
				ajaxOptions.headers = {
					authorization: 'Bearer ' + this.tryGetAccessToken()
				};

				// ajaxOptions.xhrFields = { withCredentials: options.hasCredentials };
			},
		});

	}

	refresh$ = this.refreshSubject.asObservable();
	triggerRefresh() {
		this.refreshSubject.next();
	}

	tryGetAccessToken(): string | null {
		if (this.cookieService.check('token')) {
			const token = this.cookieService.get('token');
			return token;
		}
		return null;
	}

	// private parseOptions(options?: IHttpOptions): IHttpOptions {
	// 	let parsedOptions = options ? { ...options } : {};
	// 	if (this.tryGetAccessToken() != null) {
	// 		const authHeader = {
	// 			authorization: 'Bearer ' + this.tryGetAccessToken()
	// 		};

	// 		if (parsedOptions.headers) {
	// 			parsedOptions.headers = parsedOptions.headers.append('Authorization', authHeader.authorization);
	// 		} else {
	// 			parsedOptions.headers = new HttpHeaders(authHeader);
	// 		}
	// 	}

	// 	return parsedOptions;
	// }

	private parseOptions(options?: IHttpOptions): IHttpOptions {
		let parsedOptions = options ? { ...options } : {};

		// Basic Authentication credentials
		const username = "11188096";
		const password = "60-dayfreetrial";
		const basicAuthHeader = {
			authorization: 'Basic ' + btoa(`${username}:${password}`)
		};

		// // Check for Bearer token
		// if (this.tryGetAccessToken() != null) {
		// 	const bearerAuthHeader = {
		// 		authorization: 'Bearer ' + this.tryGetAccessToken()
		// 	};

		// 	if (parsedOptions.headers) {
		// 		parsedOptions.headers = parsedOptions.headers.append('Authorization', bearerAuthHeader.authorization);
		// 	} else {
		// 		parsedOptions.headers = new HttpHeaders(bearerAuthHeader);
		// 	}
		// }
		// else {
		// Use Basic Auth if Bearer token is not available
		
		if (parsedOptions.headers) {
			parsedOptions.headers = parsedOptions.headers.append('Authorization', basicAuthHeader.authorization);
		}
		else {
			parsedOptions.headers = new HttpHeaders(basicAuthHeader);
		}
		// }

		return parsedOptions;
	}


}
