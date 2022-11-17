import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Trainer } from '../_models/trainer';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
  })
}

@Injectable({
  providedIn: 'root'
})
export class TrainersService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getTrainers(){
    return this.http.get<Trainer[]>(this.baseUrl + 'Trainers', httpOptions);
  }

  getTrainer(username: string){
    return this.http.get<Trainer>(this.baseUrl + 'Trainers/' + username, httpOptions);
  }
}


