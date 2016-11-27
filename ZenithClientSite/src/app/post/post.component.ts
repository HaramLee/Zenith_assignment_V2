import { Component, OnInit } from '@angular/core';
import {Post} from '../post';
import {JwtHelper} from '../jwt-helper';
import {PostService} from '../post.service';
import {Login} from '../login';
import {ZenithEvent} from '../zenith-event';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  results: Array<Post>;
  userData : Login;
  eventData : Array<ZenithEvent>;
  
  mem : boolean;
  eventMap = new Map<string, Array<ZenithEvent>>();
  keys = new Array<string>();
  mondayDate : Date;
  sundayDate : Date;
  weekHandler : Date;

  constructor(private postService: PostService) { 
  if(localStorage.getItem("role") == "true"){
        this.mem = false;
      }else{
        this.mem = true;
      }
  }

  ngOnInit() {
    this.getLoginToken();
    this.mondayDate = this.getMonday(new Date());
    this.sundayDate = this.getSunday(new Date());
    this.weekHandler = new Date();
  }

  getLoginToken():void{
    this.postService.userLogin("a", "P@$$w0rd")
    .then(userData => this.verifyLogin(userData))
    .catch(error => this.catchError(error));
  }


  verifyLogin(hello: any){
    this.userData = hello as Login;
    this.getActivities();
  }

  catchError(error : any){
    console.log(error);
  }

  getActivities():void{
    this.postService.getActivities(this.userData.access_token)
    .then(data => this.promisedActivites(data))
    .catch(error => this.catchError(error));
  }

  promisedActivites(temp : any){
    this.results = temp as Post[];
    this.getEvents();
  }

  getEvents():void{
    this.postService.getEvents(this.userData.access_token)
    .then(eventData => this.promisedEvents(eventData))
    .then(eventData => this.findActivities(this.eventData))
    .then(eventData => this.getBetweenDates(this.eventData))
    .catch(error => this.catchError(error));

  }
  promisedEvents(temp : any){
    this.eventData = temp as ZenithEvent[];
  
  }

  findActivities(temp: any){
    for(let z of temp){
      for(let r of this.results){
        if(z.activityId == r.activityId){
          z.ActivityName = r.activityDec;
        }
      }
    }
  }

  getMonday(day){
    day = new Date(day);
    day.setHours(24, 0, 0);
    var date = day.getDay(),
    diff = day.getDate() - date + (date == 0 ? -6:1);
    return new Date(day.setDate(diff));
  }

  getSunday(date){
    date = this.getMonday(date);
    date.setDate(date.getDate() + 6);
    return date;
  }

  getBetweenDates(events : any){
    for(let z of events){
      z.fromDate = new Date(z.fromDate);
      z.toDate = new Date(z.toDate);
      if(z.isActive){
        if(z.fromDate > this.mondayDate && z.toDate < this.sundayDate){
          if(this.eventMap.has(z.fromDate.toLocaleDateString())){
            this.eventMap.get(z.fromDate.toLocaleDateString()).push(z);
          }else{
            this.keys.push(z.fromDate.toLocaleDateString());
            this.eventMap.set(z.fromDate.toLocaleDateString(), new Array<ZenithEvent>());
            this.eventMap.get(z.fromDate.toLocaleDateString()).push(z);
          }
        }
      }
    }
    this.keys.sort(function(a, b){
      return new Date(a).getTime() - new Date(b).getTime();
    });
  }

  ahead(){
    this.eventMap = new Map<string, Array<ZenithEvent>>();
    this.keys = new Array<string>();

    this.weekHandler.setDate(this.weekHandler.getDate() + 7);
    this.mondayDate = this.getMonday(new Date(this.weekHandler.getFullYear(), this.weekHandler.getMonth(), this.weekHandler.getDate()));
    this.sundayDate = this.getSunday(new Date(this.weekHandler.getFullYear(), this.weekHandler.getMonth(), this.weekHandler.getDate()));
    this.getEvents();
  }

  behind(){
    this.eventMap = new Map<string, Array<ZenithEvent>>();
    this.keys = new Array<string>();

    this.weekHandler.setDate(this.weekHandler.getDate() - 7);
    this.mondayDate = this.getMonday(new Date(this.weekHandler.getFullYear(), this.weekHandler.getMonth(), this.weekHandler.getDate()));
    this.sundayDate = this.getSunday(new Date(this.weekHandler.getFullYear(), this.weekHandler.getMonth(), this.weekHandler.getDate()));
    this.getEvents();
  }
} 