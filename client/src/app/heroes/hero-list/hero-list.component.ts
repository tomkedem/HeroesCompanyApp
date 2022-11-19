import { Component, OnInit } from '@angular/core';
import { Hero } from 'src/app/_models/hero';
import { AccountService } from 'src/app/_services/account.service';
import { HeroesService } from 'src/app/_services/heroes.service';

@Component({
  selector: 'app-hero-list',
  templateUrl: './hero-list.component.html',
  styleUrls: ['./hero-list.component.css']
})
export class HeroListComponent implements OnInit {

  heroes: Hero[];
  constructor(private heroesService: HeroesService , private accountService: AccountService) { }

  ngOnInit(): void {
    this.loadHeroes();
  }
  trainerId:number;
  model: any
  loadHeroes(){

    this.accountService.currentUser$.subscribe(a => { this.trainerId=a.id; });

    this.heroesService.getHeroesByTrainerId(this.trainerId).subscribe(heroes =>{
      this.heroes= heroes;
    })

  }
}
