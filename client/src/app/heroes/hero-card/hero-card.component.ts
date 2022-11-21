import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { Hero } from 'src/app/_models/hero';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { HeroesService } from 'src/app/_services/heroes.service';

@Component({
  selector: 'app-hero-card',
  templateUrl: './hero-card.component.html',
  styleUrls: ['./hero-card.component.css'],
})
export class HeroCardComponent implements OnInit {
  @Input() hero: Hero;

  canBeTrain:boolean =true;
   constructor(private accountService: AccountService, private heroesService: HeroesService, private toastr: ToastrService) { }




  ngOnInit(): void {
    let currentUser: User;

    this.accountService.currentUser$.pipe(take(1)).subscribe(user => currentUser = user);

    console.log('currentUser.id===>', currentUser.id)
    console.log('trainerId===>', this.hero.trainerId)
    if(this.hero.trainerId == currentUser.id) {
      console.log('trainerIdAAA===>', this.hero.trainerId)
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


}
