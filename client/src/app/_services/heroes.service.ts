import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Hero } from '../_models/hero';

@Injectable({
  providedIn: 'root'
})
export class HeroesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getHeroes(){
      return this.http.get<Hero[]>(this.baseUrl + 'Heroes');
  }

  getHero(username: string){
      return this.http.get<Hero>(this.baseUrl + 'Heroes/' + username);
  }

  getHeroesByTrainerId(trainerId: number){
      return this.http.get<Hero[]>(this.baseUrl + 'Heroes/ByTrainerId/' + trainerId);
  }

  updateHero(hero: Hero){
    console.log('updateHero',hero)

    return this.http.put<Hero>(this.baseUrl + 'Heroes/UpdateHero' , hero);
  }
}
