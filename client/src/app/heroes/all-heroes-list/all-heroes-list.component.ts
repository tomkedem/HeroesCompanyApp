import { Component, OnInit } from '@angular/core';
import { Hero } from 'src/app/_models/hero';
import { HeroesService } from 'src/app/_services/heroes.service';

@Component({
  selector: 'app-all-heroes-list',
  templateUrl: './all-heroes-list.component.html',
  styleUrls: ['./all-heroes-list.component.css']
})
export class AllHeroesListComponent implements OnInit {

  heroes: Hero[];
  constructor(private heroesService: HeroesService) { }

  ngOnInit(): void {
    this.loadHeroes();
  }
  trainerId:number;
  model: any
  loadHeroes(){

    this.heroesService.getHeroes().subscribe(heroes =>{
      this.heroes= heroes;
    })

  }
}
