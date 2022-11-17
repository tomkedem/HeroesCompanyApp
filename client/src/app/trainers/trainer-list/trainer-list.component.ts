import { Component, OnInit } from '@angular/core';
import { Trainer } from 'src/app/_models/trainer';
import { TrainersService } from 'src/app/_services/trainers.service';

@Component({
  selector: 'app-trainer-list',
  templateUrl: './trainer-list.component.html',
  styleUrls: ['./trainer-list.component.css']
})
export class TrainerListComponent implements OnInit {
  trainers: Trainer[];
  constructor(private trainersService: TrainersService) { }

  ngOnInit(): void {
    this.loadTrainers()
  }

  loadTrainers(){
    this.trainersService.getTrainers().subscribe(trainers =>{
      this.trainers= trainers;
    })
  }

}
