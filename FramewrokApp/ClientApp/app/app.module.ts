﻿import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { SharedAppModeule } from "./shared/shared.module";
import { CommonModeule } from "./common/common.module";
import { RouteModeule } from "./app.route.module";
@NgModule({
    imports:
    [
        BrowserModule,
        FormsModule,
        SharedAppModeule,
        CommonModeule,
        //RouteModeule
    ],
    
    declarations:
    [
        AppComponent
    ],
    bootstrap:
    [
        AppComponent,
    ]
})
export class AppModule { }