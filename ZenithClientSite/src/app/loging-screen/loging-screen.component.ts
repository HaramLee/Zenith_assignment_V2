import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {PostService} from '../post.service';
import {User} from '../user';
import {Login} from '../login';
import {RoleReturn} from '../role-return';

@Component({
  selector: 'app-loging-screen',
  templateUrl: './loging-screen.component.html',
  styleUrls: ['./loging-screen.component.css']
})
export class LogingScreenComponent implements OnInit {

  curUser: Login
  curRole: RoleReturn
  alive : boolean
  constructor(
    private postService: PostService,
    private router : Router
  ) { 
  if(localStorage.getItem("role") == "true"){
      this.alive = false;
    }else{
      this.alive = true;
    }

  }

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
    this.postService.getRole(localStorage.getItem("token"))
    .then(res => this.finishRoles(res))
    .catch(error => this.catchError(error));
  }

  finishRoles(tmp : any){
    this.curRole = tmp;
    localStorage.setItem("role", this.curRole.value);
    this.router.navigate(['../']);
    window.location.reload();
  }
  
  catchError(error : any){
    console.log(error);
  }

}
