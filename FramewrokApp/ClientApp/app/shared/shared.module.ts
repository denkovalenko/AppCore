import { NgModule } from "@angular/core";
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCheckboxModule, MatInputModule, MatFormFieldModule, MatRippleModule } from '@angular/material';

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
        MatRippleModule
    ],
})

export class SharedAppModeule { }