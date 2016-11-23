import { Http, Headers, RequestOptions } from "@angular/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import "rxjs/add/operator/map";

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

    public constructor(private http: Http) { }

    public getUsers(): Observable<IUser[]> {
        return this.http.get("/api/users", this.authorizedHeaders())
            .map(res => <IUser[]>res.json());
    }

    public getUser(userId: number): Observable<IUser> {
        return this.http.get(`/api/users/${userId}`, this.authorizedHeaders())
            .map(res => <IUser>res.json());
    }

    public upsertUser(user: IUser): Observable<IUser> {
        if (user.userId) {
            // Update
            return this.http.put(`/api/users/${user.userId}`, user, this.authorizedHeaders())
                .map(res => res.json());
        } else {
            // Create
            return this.http.post("/api/users", user, this.authorizedHeaders())
                .map(res => res.json());
        }
    }

    public delete(userId: number): Observable<any> {
        return this.http.delete(`/api/users/${userId}`, this.authorizedHeaders());
    }

    // https://angular.io/docs/ts/latest/guide/server-communication.html#!#update
    private authorizedHeaders() {
        let accessToken = localStorage.getItem("accessToken");
        let headerObject = { "Content-Type": "application/json" };
        console.log(headerObject);
        if (accessToken) {
            headerObject["Token"] = accessToken;
        } 
        let headers = new Headers(headerObject);

        return new RequestOptions({ headers: headers });
    }
}