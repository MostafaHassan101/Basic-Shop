import { Injectable } from '@angular/core';
import { ApiClientService } from '../api-client.service';
import { CookieService } from 'ngx-cookie-service';
import { jwtDecode } from 'jwt-decode';
import { BehaviorSubject, Observable } from 'rxjs';

const authEndpoint = "api/auth";

@Injectable({
	providedIn: 'root'
})

export class UserService {

	// private isAuthenticated = new Subject<boolean>();
	// anther way to do it
	private isAuthenticated = new BehaviorSubject<boolean>(false);
	// userName
	private userName = new BehaviorSubject<string>('');
	constructor(private coreService: ApiClientService, private cookieService: CookieService) {
		this.isAuthenticated.next(this.cookieService.check('token'));
	}

	getUserData() {
		return this.coreService.get(`${authEndpoint}/user`);
	}

	registerUser(user: any, returnUrl?: string) {
		return this.coreService.post(`${authEndpoint}/register`, user);
	}

	loginUser(email: string, password: string, returnUrl?: string, addItemsCommand?: any) {
		const command = { email, password, returnUrl, addItemsCommand };
		return this.coreService.post(`${authEndpoint}/login`, command);
	}

	updateUserData(userData: any) {
		return this.coreService.put(`${authEndpoint}/update`, userData);
	}

	logoutUser() {
		return this.coreService.post(`${authEndpoint}/logout`);
	}

	userIsExists(email: string) {
		const endpoint = `/IsExists?email=${email}`;
		return this.coreService.get(authEndpoint + endpoint);
	}

	getUserClaims(token?: string) {
		token = this.cookieService.get('token');
		if (token) {
			const decodedToken: any = jwtDecode(token);
			return decodedToken;
		}
		else {
			return null;
		}
	}

	setAuthStatus(value: boolean) {
		this.isAuthenticated.next(value);
	}
	getAuthStatus(): Observable<boolean> {
		return this.isAuthenticated.asObservable();
	}

	changePassword(changePassword: any) {
		return this.coreService.post(`${authEndpoint}/change-password`, changePassword);
	}

	getUserName() {
		return this.userName.asObservable();
	}
	setUserName() {
		const userClaims = this.getUserClaims();
		const userName = userClaims.given_name + ' ' + userClaims.family_name
		if (userClaims)
			this.userName.next(userName);
	}
}
