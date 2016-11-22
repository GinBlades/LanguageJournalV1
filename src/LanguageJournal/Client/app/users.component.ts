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
        this.getUsers();
    }

    public showUser(userId) {
        this.http.get(`/api/users/${userId}`)
            .map(res => res.json())
            .subscribe(user => this.activeUser = user);
    }

    public newUser() {
        this.activeUser = {};
    }

    public onSubmit() {
        // Update
        if (this.activeUser.userId) {
            this.http.put(`/api/users/${this.activeUser.userId}`, this.activeUser)
                .map(res => res.json())
                .subscribe(_ => this.refresh());
        // Create
        } else {
            this.http.post("/api/users", this.activeUser)
                .map(res => res.json())
                .subscribe(_ => this.refresh());
        }
        console.log(this.activeUser);
    }

    public removeUser(userId) {
        if (!confirm("Are you sure you want to remove this user?")) { return; }

        this.http.delete(`/api/users/${userId}`)
            .subscribe(_ => this.refresh());
    }

    private getUsers() {
        this.http.get("/api/users")
            .map(res => res.json())
            .subscribe(users => this.users = users);
    }

    private refresh() {
        this.activeUser = undefined;
        this.getUsers();
    }
}