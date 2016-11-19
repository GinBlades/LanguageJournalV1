import { Component } from "@angular/core";

@Component({
    selector: "my-app",
    template: `<h1>Language Journal</h1>
        <nav>
            <ul>
                <li><a routerLink="/home" routerLinkActive="active">Home</a></li>
                <li><a routerLink="/users" routerLinkActive="active">Users</a></li>
                <li><a routerLink="/entries" routerLinkActive="active">Entries</a></li>
            </ul>
        </nav>
        <router-outlet></router-outlet>
    `
})
export class AppComponent { }