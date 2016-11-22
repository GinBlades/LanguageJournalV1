import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { HomeComponent } from "./home.component";
import { UsersComponent } from "./users.component";
import { EntriesComponent } from "./entries.component";
import { SigninComponent } from "./signin.component";

const routes: Routes = [
    { path: "", redirectTo: "/home", pathMatch: "full" },
    { path: "home", component: HomeComponent },
    { path: "users", component: UsersComponent },
    { path: "entries", component: EntriesComponent },
    { path: "signin", component: SigninComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    exports: [RouterModule]
})
export class AppRoutingModule { }