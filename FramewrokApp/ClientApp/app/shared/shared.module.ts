import { NgModule } from "@angular/core";
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCheckboxModule, MatInputModule, MatFormFieldModule, MatRippleModule, MatMenuModule, ErrorStateMatcher, ShowOnDirtyErrorStateMatcher, MatTableModule } from '@angular/material';
import { RouteModeule } from "../app.route.module";
import { AuthenticationService } from "./components/authentication-component/authentication.service ";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";

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
        ReactiveFormsModule
    ],
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
        { provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher }
    ]
})

export class SharedAppModeule { }