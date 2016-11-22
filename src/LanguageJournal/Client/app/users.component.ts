import { Component } from "@angular/core";
import { IUser, UserService } from "./user.service";

@Component({
    selector: "users",
    templateUrl: "app/users.component.html"
})
export class UsersComponent {
    public users: IUser[];
    public activeUser: IUser;
    constructor(private userService: UserService) { }

    public ngOnInit(): void {
        this.userService.getUsers()
            .subscribe(users => this.users = users);
    }

    public showUser(userId: number): void {
        this.userService.getUser(userId)
            .subscribe(user => this.activeUser = user);
    }

    public newUser(): void {
        this.activeUser = <IUser>{};
    }

    public onSubmit(): void {
        this.userService.upsertUser(this.activeUser)
            .subscribe(_ => this.refresh());
    }

    public removeUser(userId: number): void {
        if (!confirm("Are you sure you want to remove this user?")) { return; }

        this.userService.delete(userId)
            .subscribe(_ => this.refresh());
    }
    
    private refresh(): void {
        this.activeUser = undefined;
        this.userService.getUsers()
            .subscribe(users => this.users = users);
    }
}