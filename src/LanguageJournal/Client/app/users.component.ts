import { Component } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/map";

@Component({
    selector: "users",
    templateUrl: "app/users.component.html"
})
export class UsersComponent {
    public users;
    public activeUser;
    constructor(private http: Http) { }

    public ngOnInit() {
        this.http.get("/api/users")
            .map(res => res.json())
            .subscribe(users => this.users = users);
    }

    public showUser(userId) {
        this.http.get(`/api/users/${userId}`)
            .map(res => res.json())
            .subscribe(user => this.activeUser = user);
    }
}