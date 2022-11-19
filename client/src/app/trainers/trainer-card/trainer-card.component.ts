import { Component, Input, OnInit, Output } from '@angular/core';
import { Trainer } from 'src/app/_models/trainer';

@Component({
  selector: 'app-trainer-card',
  templateUrl: './trainer-card.component.html',
  styleUrls: ['./trainer-card.component.css']
})
export class TrainerCardComponent implements OnInit {
  @Input() trainer: Trainer;
  @Output() rt;
  constructor() { }

  ngOnInit(): void {
    console.log('trainer==>')
   
  }

}
