import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { UserService } from './user-management/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {
  isAuthenticated: boolean = false;
  constructor(public auth: UserService, public router: Router) {
    this.auth.getAuthStatus().subscribe(
      {
        next: (response: any) => {
          this.isAuthenticated = response;
        },
        error: (err: any) => {
        }
      })
  }
  canActivate(route: ActivatedRouteSnapshot): boolean {
    // this will be passed from the route config
    // on the data property
    // const expectedRole = route.data.expectedRole;
    // const token = localStorage.getItem('toke1n');
    // decode the token to get its payload
    // const tokenPayload = decode(token);
    
    if (!this.isAuthenticated) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
}
