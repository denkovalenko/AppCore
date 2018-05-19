import { NgModule } from "@angular/core";
import { HeaderComponent } from "./header/header.component";
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./login/login.component";
import { SharedAppModeule } from "../shared/shared.module";

@NgModule({
    imports:
    [
        SharedAppModeule,
    ],
    exports:
    [
        HeaderComponent,
        HomeComponent,
        LoginComponent
    ],
    declarations:
    [
        HeaderComponent,
        HomeComponent,
        LoginComponent
    ],
})

export class CommonModeule { }