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
  jwtHelper: JwtHelper = new JwtHelper();

  eventMap = new Map<string, Array<ZenithEvent>>();
  keys = new Array<string>();
  mondayDate : Date;
  sundayDate : Date;

  constructor(private postService: PostService) { }

  ngOnInit() {
    this.postService.getAll().subscribe(
      data => this.getResults(data),
      error => console.log(error)
    );
    //this.getLoginToken();
    this.mondayDate = this.getMonday(new Date());
    this.sundayDate = this.getSunday();
  }

  getResults(tmp : any){
    this.results = tmp as Array<Post>;
    this.getLoginToken();
  }

  getLoginToken():void{
    this.postService.userLogin("a", "P@$$w0rd")
    .then(userData => this.verifyLogin(userData))
    .catch(error => this.catchError(error));


  }


  verifyLogin(hello: any){
    this.userData = hello as Login;
    this.getEvents();
  }

  catchError(error : any){
    console.log(error);
  }

  getEvents():void{
    this.postService.getEvents(this.userData.access_token)
    .then(eventData => this.promisedEvents(eventData))
    .then(eventData => this.findActivities(this.eventData))
    .then(eventData => this.getBetweenDates(this.eventData))
    .catch(error => this.catchError(error));


    var decoded = this.jwtHelper.decodeToken(this.userData.access_token);
    //console.log(decoded);
  }
  promisedEvents(temp : any){
    this.eventData = temp as ZenithEvent[];
  
  }

  findActivities(temp: any){
    for(let z of temp){
      for(let r of this.results){
        if(z.activityId == r.activityId){
          z.ActivityName = r.activityDec;
         // console.log(z.ActivityName);
        }
      }
    }
  }

  getMonday(day){
    day = new Date(day);
    day.setHours(24, 0, 0);
    console.log(day);
    var date = day.getDay(),
    diff = day.getDate() - date + (date == 0 ? -6:1);
    return new Date(day.setDate(diff));
  }

  getSunday(){
    var date = new Date();
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
} 