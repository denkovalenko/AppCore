import { NgModule } from "@angular/core";
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCheckboxModule, MatInputModule, MatFormFieldModule, MatRippleModule, MatMenuModule } from '@angular/material';
import { RouteModeule } from "../app.route.module";
import { AuthenticationService } from "./components/authentication-component/authentication.service ";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { TokenInterceptor } from "./components/authentication-component/token-interceptor.service";
import { HomeService } from "../common/home/shared/services/home.service";

@NgModule({
    imports:
    [
        NoopAnimationsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        MatFormFieldModule,
        MatInputModule,
        MatRippleModule,
        MatMenuModule,
        RouteModeule,
        HttpClientModule,
    ],
    exports:
    [
        FormsModule,
        NoopAnimationsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        MatFormFieldModule,
        MatInputModule,
        MatRippleModule,
        MatMenuModule,
        RouteModeule,
    ],
    providers:
    [
        { provide: AuthenticationService, useClass: AuthenticationService },
        { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
        { provide: HomeService, useClass: HomeService }
    ]
})

export class SharedAppModeule { }