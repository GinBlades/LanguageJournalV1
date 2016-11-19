import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home.component";
import { UsersComponent } from "./users.component";
import { EntriesComponent } from "./entries.component";
import { AppRoutingModule } from "./app-routing.module";

@NgModule({
    imports: [
        BrowserModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        UsersComponent,
        EntriesComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }