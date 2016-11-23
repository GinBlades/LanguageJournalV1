import { Http } from "@angular/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import "rxjs/add/operator/map";

import { AuthenticatorService } from "./authenticator.service";

export interface IUser {
    userId: number;
    name: string;
    email: string;
    bio: string;
    password: string;
    tokens: any[];
    userLanguages: any[];
}

@Injectable()
export class UserService {

    public constructor(private http: Http, private authenticatorService: AuthenticatorService) { }

    public getUsers(): Observable<IUser[]> {
        return this.http.get("/api/users", this.authenticatorService.authorizedHeaders())
            .map(res => <IUser[]>res.json());
    }

    public getUser(userId: number): Observable<IUser> {
        return this.http.get(`/api/users/${userId}`, this.authenticatorService.authorizedHeaders())
            .map(res => <IUser>res.json());
    }

    public upsertUser(user: IUser): Observable<IUser> {
        if (user.userId) {
            // Update
            return this.http.put(`/api/users/${user.userId}`, user, this.authenticatorService.authorizedHeaders())
                .map(res => res.json());
        } else {
            // Create
            return this.http.post("/api/users", user, this.authenticatorService.authorizedHeaders())
                .map(res => res.json());
        }
    }

    public delete(userId: number): Observable<any> {
        return this.http.delete(`/api/users/${userId}`, this.authenticatorService.authorizedHeaders());
    }
}