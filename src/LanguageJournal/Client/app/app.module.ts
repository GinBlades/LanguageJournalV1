import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";
import { FormsModule } from "@angular/forms";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home.component";
import { UsersComponent } from "./users.component";
import { EntriesComponent } from "./entries.component";
import { AppRoutingModule } from "./app-routing.module";

@NgModule({
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpModule,
        FormsModule
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