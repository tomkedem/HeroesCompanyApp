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

   constructor(private heroesService: HeroesService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

t:any

  pop(){
    this.powerGrowsUp=1
     this.t=Math.random()
      console.log(this.hero.currentPower)
      console.log('Hi tom powerGrowsUp: ' + Number(this.powerGrowsUp)*2)
      ///this.t = this.powerGrowsUp.toFixed(2)*2 ;

      let p1 =parseFloat(this.powerGrowsUp)
      console.log('Hi tom powerGrowsUpP1: ' + p1)
      console.log('Hi tom powerGrowsUpX: ' + (this.t.toFixed(2)))

    }
    updateHero(){
      this.heroesService.updateHero(this.hero).subscribe(() =>{
        this.toastr.success('Profile updated successfully');
      })
    }
//  * 10 .tofixed(2)

// number.toFixed(2)

}
