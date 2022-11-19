import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Hero } from 'src/app/_models/hero';
import { HeroesService } from 'src/app/_services/heroes.service';

@Component({
  selector: 'app-hero-card',
  templateUrl: './hero-card.component.html',
  styleUrls: ['./hero-card.component.css'],
})
export class HeroCardComponent implements OnInit {
  @Input() hero: Hero;
  powerGrowsUp
  canBeTrain:boolean =false;
   constructor(private heroesService: HeroesService, private toastr: ToastrService) { }

  ngOnInit(): void {
    const date = new Date();
    let strToday = date.toLocaleString().toString().substring(0, 10);

    let strOldDateF = new Date(this.hero.trainingDate).toLocaleString();

    let strOldDate = strOldDateF.toString().substring(0, 10);
   
    if(strOldDate != strToday) this.hero.totalTrainingToday=0;

    if(Number(this.hero.totalTrainingToday) === 0){
      this.canBeTrain=false
    }else if(Number(this.hero.totalTrainingToday) < 5){
      this.canBeTrain=false
    }else{
      this.canBeTrain=true
    }
  }

t:any

  pop(){
    this.powerGrowsUp=1
     this.t=Math.random()
      console.log(this.hero.currentPower)
      console.log('Hi tom powerGrowsUp: ' + Number(this.powerGrowsUp)*2)

      let p1 =parseFloat(this.powerGrowsUp)
      console.log('Hi tom powerGrowsUpP1: ' + p1)
      console.log('Hi tom powerGrowsUpX: ' + (this.t.toFixed(2)))

    }
    updateHero(){
      this.heroesService.updateHero(this.hero).subscribe(
        (successResponse) => {
          this.hero = successResponse;
          if(Number(this.hero.totalTrainingToday) === 0){
            this.canBeTrain=false
          }else if(Number(this.hero.totalTrainingToday) < 5){
            this.canBeTrain=false
          }else{
            this.canBeTrain=true
          }
          this.toastr.success('Current power updated successfully');
        },
        (errorResponse) => {
          console.log(errorResponse);
        }

      )
    }
//  * 10 .tofixed(2)

// number.toFixed(2)

}
