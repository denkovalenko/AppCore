import { Component } from '@angular/core';
import { AuthenticationService } from "../../shared/components/authentication-component/authentication.service ";
import { LoginModel } from "../../shared/models/login.model";
import { Router } from "@angular/router";
import { OnInit } from "@angular/core";

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    loginModel: LoginModel;
    constructor(private authenticationService: AuthenticationService,
        private router: Router) {
    }

    ngOnInit() {
        this.loginModel = new LoginModel();
    }

    logIn() {
        this.loginModel.userName = "starvladislav@gmail.com";
        this.loginModel.password = "123123";
        this.authenticationService.isAuthenticated(this.loginModel).subscribe((res) => {
            if (res) {
                this.router.navigate(['/home']);
            }
        });
    }
}