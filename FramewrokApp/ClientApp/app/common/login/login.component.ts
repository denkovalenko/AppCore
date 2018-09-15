import { Component } from '@angular/core';
import { AuthenticationService } from "../../shared/components/authentication-component/authentication.service ";
import { LoginModel } from "../../shared/models/login.model";
import { Router } from "@angular/router";
import { OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Validators } from "@angular/forms";
import { MyErrorStateMatcher } from "../../shared/components/error-component/my-error-state-matcher.component";

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    loginModel: LoginModel;
    error: any;
    //emailFormControl: any;
    //matcher: any;
    emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
    ]);
    matcher = new MyErrorStateMatcher();
    constructor(private authenticationService: AuthenticationService,
        private router: Router) {
    }

    
    
    ngOnInit() {
        this.loginModel = new LoginModel();
        //this.emailFormControl = new FormControl('', [
        //    Validators.required,
        //    Validators.email,
        //]);
        //this.matcher = new MyErrorStateMatcher();
    }

    logIn() {
        this.authenticationService.isAuthenticated(this.loginModel).subscribe((res) => {
            if (res) {
                this.router.navigate(['/home']);
            } else {
                this.error = 'Invalid username or password';
            }
        });
    }
}