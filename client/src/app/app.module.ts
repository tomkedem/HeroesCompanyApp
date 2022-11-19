import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';

import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';

import { NavComponent } from './nav/nav.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { HeroListComponent } from './heroes/hero-list/hero-list.component';
import { HeroDetailComponent } from './heroes/hero-detail/hero-detail.component';
import { SharedModule } from './_modules/shared.module';
import { TestErrorsComponent } from './Errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './Errors/not-found/not-found.component';
import { ServerErrorComponent } from './Errors/server-error/server-error.component';
import { TrainerDetailComponent } from './trainers/trainer-detail/trainer-detail.component';
import { TrainerListComponent } from './trainers/trainer-list/trainer-list.component';
import { TrainerCardComponent } from './trainers/trainer-card/trainer-card.component';
import { HeroCardComponent } from './heroes/hero-card/hero-card.component';
import { AllHeroesListComponent } from './heroes/all-heroes-list/all-heroes-list.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegisterComponent,
    NavComponent,
    ListsComponent,
    MessagesComponent,
    HeroListComponent,
    HeroDetailComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TrainerDetailComponent,
    TrainerListComponent,
    TrainerCardComponent,
    HeroCardComponent,
    AllHeroesListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
