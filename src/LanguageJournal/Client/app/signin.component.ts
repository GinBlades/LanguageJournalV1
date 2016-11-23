import { Component } from "@angular/core";

import { AuthenticatorService } from "./authenticator.service";

@Component({
    selector: "signin",
    templateUrl: "app/signin.component.html"
})
export class SigninComponent {
    public signinUser;

    constructor(private authenticatorService: AuthenticatorService) {}

    public ngOnInit() {
        this.signinUser = {};
    }

    public signin() {
        this.authenticatorService.signIn(this.signinUser);
    }
}