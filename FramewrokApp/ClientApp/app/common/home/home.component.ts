import { Component, OnInit } from '@angular/core';
import { HomeService } from "./shared/services/home.service";

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
    users: any;
    constructor(private homeService: HomeService) { }

    ngOnInit() {
        this.getUsers();
    }

    getUsers() {
        this.homeService.getUser().subscribe((result) => {
            this.users = result;
        });
    }
}