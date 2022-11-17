import { Component, OnInit } from '@angular/core';
import { Hero } from 'src/app/_models/hero';
import { HeroesService } from 'src/app/_services/heroes.service';

@Component({
  selector: 'app-hero-list',
  templateUrl: './hero-list.component.html',
  styleUrls: ['./hero-list.component.css']
})
export class HeroListComponent implements OnInit {

  heroes: Hero[];
  constructor(private heroesService: HeroesService) { }

  ngOnInit(): void {
    this.loadHeroes();
  }

  loadHeroes(){
    this.heroesService.getHeroes().subscribe(heroes =>{
      this.heroes= heroes;
    })
  }
}
