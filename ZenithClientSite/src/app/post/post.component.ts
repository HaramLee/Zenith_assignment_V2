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

  constructor(private postService: PostService) { }

  ngOnInit() {
    this.postService.getAll().subscribe(
      data => { this.results = data; },
      error => console.log(error)
    );
    this.getLoginToken();
    //this.getEvents();
    
    //console.log(decoded);
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
    .catch(error => this.catchError(error));


    var decoded = this.jwtHelper.decodeToken(this.userData.access_token);
    console.log(decoded);
    /*this.eventData.forEach(e => {
      this.results.forEach(a => {
        if(a.activityId == e.ActivityId){
         // e.ActivityName = a.activityDec;
        }
      });
    });*/
  }
  promisedEvents(temp : any){
    this.eventData = temp as ZenithEvent[];
    console.log(this.eventData);
  }
} 