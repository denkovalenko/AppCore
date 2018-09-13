import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from "../../shared/components/authentication-component/authentication.service ";
import { UserInfo } from "../../shared/models/user-info.model";

@Component({
    selector: 'header',
    templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {

    public user: UserInfo;

    constructor(private authenticationService: AuthenticationService) { }

    ngOnInit() {
        this.chekUser();
    }

    chekUser() {
        this.user = this.authenticationService.getUserInfo();
        console.log(this.user)
    }

    public logout() {
        localStorage.clear();
    }
}