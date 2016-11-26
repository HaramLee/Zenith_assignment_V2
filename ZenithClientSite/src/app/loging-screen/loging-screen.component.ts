import { Component, OnInit } from '@angular/core';
import {PostService} from '../post.service';
import {User} from '../user';
import {Login} from '../login';

@Component({
  selector: 'app-loging-screen',
  templateUrl: './loging-screen.component.html',
  styleUrls: ['./loging-screen.component.css']
})
export class LogingScreenComponent implements OnInit {

  curUser: Login
  constructor(
    private postService: PostService
  ) { }

  ngOnInit() {
  }
  
  user : User = new User();
  add(loginUser : User){
    this.postService.userLogin(loginUser.username, loginUser.password)
    .then(result => this.finishLogin(result))
    .catch(error => this.catchError(error));
  }

  finishLogin(temp : any){
    this.curUser = temp;
    localStorage.setItem("token", this.curUser.access_token);
    console.log(this.curUser.access_token);
  }
  
  catchError(error : any){
    console.log(error);
  }

}
