import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UserInfo } from "../models/user-info.model";

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        //if (localStorage.getItem('tokenInfo')) {
        //    // logged in so return true
        //    return true;
        //}

        let userInfo = JSON.parse(localStorage.getItem('userInfo'));
        console.log(JSON.parse(localStorage.getItem('userInfo')));
        let info = <UserInfo>userInfo

        if (info) {
            return true;
        }
        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}