import { NgModule } from "@angular/core";
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCheckboxModule, MatInputModule, MatFormFieldModule, MatRippleModule, MatMenuModule, ErrorStateMatcher, ShowOnDirtyErrorStateMatcher, MatTableModule } from '@angular/material';
import { RouteModeule } from "../app.route.module";
import { AuthenticationService } from "./components/authentication-component/authentication.service ";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { TokenInterceptor } from "./components/authentication-component/token-interceptor.service";
import { HomeService } from "../common/home/shared/services/home.service";

@NgModule({
    imports:
    [
        FormsModule,
        NoopAnimationsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        MatFormFieldModule,
        MatRippleModule,
        MatMenuModule,
        RouteModeule,
        HttpClientModule,
        MatTableModule,
        BrowserModule,
        ReactiveFormsModule    ],
    exports:
    [
        FormsModule,
        NoopAnimationsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        MatFormFieldModule,
        MatRippleModule,
        MatMenuModule,
        RouteModeule,
        MatTableModule
    ],
    providers:
    [
        { provide: AuthenticationService, useClass: AuthenticationService },
        { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
        { provide: HomeService, useClass: HomeService }
    ]
})

export class SharedAppModeule { }