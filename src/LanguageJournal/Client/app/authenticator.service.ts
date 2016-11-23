import { Http, Headers, RequestOptions } from "@angular/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, Subject } from "rxjs/Rx";
import "rxjs/add/operator/map";

export interface ISigninUser {
    username?: string;
    email?: string;
    password: string;
}

export interface IAuthToken {
    token: string;
}

@Injectable()
export class AuthenticatorService {

    public signedIn: boolean;
    // http://stackoverflow.com/questions/34714462/updating-variable-changes-in-components-from-a-service-with-angular2
    public signInChange: Subject<boolean> = new Subject<boolean>();

    public constructor(private http: Http, private router: Router) {
        this.signedIn = localStorage.getItem("accessToken") ? true : false;
    }

    // https://angular.io/docs/ts/latest/guide/server-communication.html#!#update
    public authorizedHeaders(): RequestOptions {
        let accessToken = localStorage.getItem("accessToken");
        let headerObject = { "Content-Type": "application/json" };
        if (accessToken) {
            headerObject["Token"] = accessToken;
        }
        let headers = new Headers(headerObject);

        return new RequestOptions({ headers: headers });
    }

    public signIn(user: ISigninUser): void {
        this.http.post("/api/sessions/signin", user)
            .map(res => res.json()).subscribe((t) => {
                this.setToken(t);
                this.isSignedIn();
        });
    }

    public setToken(token: IAuthToken) {
        localStorage.setItem("accessToken", token.token);
        this.router.navigate(["/home"]);
    }

    public signOut(): void {
        localStorage.removeItem("accessToken");
        this.isSignedIn();
        this.router.navigate(["/home"]);
    }

    public isSignedIn(): void {
        let access = localStorage.getItem("accessToken") ? true : false;
        this.signInChange.next(access);
    }
}