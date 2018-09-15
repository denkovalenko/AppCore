import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from "../../shared/components/authentication-component/authentication.service ";
import { UserInfo } from "../../shared/models/user-info.model";
import { Router } from "@angular/router";

@Component({
    selector: 'header',
    templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {

    public user: UserInfo;

    constructor(private authenticationService: AuthenticationService,
        private router: Router) { }

    ngOnInit() {
        this.chekUser();
    }

    chekUser() {
        this.user = this.authenticationService.getUserInfo();
        console.log(this.user)
    }

    public logout() {
        localStorage.clear();
        this.router.navigate(['/login']);
    }
}