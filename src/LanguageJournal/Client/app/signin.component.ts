import { Component } from "@angular/core";
import { Http } from "@angular/http";
import { Router } from "@angular/router";
import "rxjs/add/operator/map";

@Component({
    selector: "signin",
    templateUrl: "app/signin.component.html"
})
export class SigninComponent {
    public signinUser;

    constructor(private http: Http, private router: Router) {}

    public ngOnInit() {
        this.signinUser = {};
    }

    public signin() {
        this.http.post("/api/sessions/signin", this.signinUser)
            .map(res => res.json())
            .subscribe((t) => {
                localStorage.setItem("accessToken", t.token);
                this.router.navigate(["/home"]);
            });
    }
}