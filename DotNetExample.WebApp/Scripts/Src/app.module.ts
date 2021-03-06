﻿import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

@NgModule({
    imports: [
        //angular builtin module
        BrowserModule,
        HttpModule,
        JsonpModule,
        FormsModule
    ],
    declarations: [
        AppComponent
    ],
    providers: [
        //register services here
    ],
    bootstrap: [
        AppComponent
    ]
})

export class AppModule {
}

