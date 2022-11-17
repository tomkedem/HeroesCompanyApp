import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Hero } from '../_models/hero';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
  })
}

@Injectable({
  providedIn: 'root'
})
export class HeroesService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getHeroes(){
    return this.http.get<Hero[]>(this.baseUrl + 'Heroes', httpOptions);
  }

  getHero(username: string){
    return this.http.get<Hero>(this.baseUrl + 'Heroes/' + username, httpOptions);
  }
}
