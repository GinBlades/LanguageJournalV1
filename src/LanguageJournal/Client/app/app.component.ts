import { Component } from "@angular/core";
import { AuthenticatorService } from "./authenticator.service";
@Component({
    selector: "my-app",
    templateUrl: "app/app.component.html"
})
export class AppComponent {
    public isSignedIn: boolean;
    private _subscription: any;

    constructor(private authenticatorService: AuthenticatorService) {
        this._subscription = this.authenticatorService.signInChange.subscribe((value) => {
            this.isSignedIn = value;
        });
    }

    public signOut() {
        this.authenticatorService.signOut();
    }

    public ngOnDestroy() {
        this._subscription.unsubscribe();
    }
}