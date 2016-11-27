import { Component, OnInit } from '@angular/core';
import {RegisterUser} from '../register-user';
import {User} from '../user';
import {Login} from '../login';
import {RegisterReturn} from '../register-return';
import {PostService} from '../post.service';

@Component({
  selector: 'app-register-screen',
  templateUrl: './register-screen.component.html',
  styleUrls: ['./register-screen.component.css']
})
export class RegisterScreenComponent implements OnInit {

curLoginInfo : Login;
 curUser : User;
 registerReturn : RegisterReturn;
 alive : boolean;

  constructor(
    private postService: PostService
  ) {
    if(localStorage.getItem("role") == "true"){
      this.alive = false;
    }else{
      this.alive = true;
    }
   }

  ngOnInit() {
  }

  newUser : RegisterUser = new RegisterUser();
  register(newUser: RegisterUser){
    if(!newUser){
      return;
    }
    newUser.firstName = newUser.firstName.trim();
    newUser.lastName = newUser.lastName.trim();
    newUser.email = newUser.email.trim();
    newUser.userName = newUser.userName.trim();
    newUser.passwordHash = newUser.passwordHash.trim();

    this.postService.userRegister(newUser)
    .then(result => this.finishRegister(result))
    .catch(error => this.catchError(error));
  }

  finishRegister(temp: any){
    this.registerReturn = temp;
    if(this.registerReturn.statusCode == "200"){
      this.postService.userLogin(this.newUser.userName, this.newUser.passwordHash)
      .then(result => this.finishLogin(result))
      .catch(error => this.catchError(error));
    }
  }

  finishLogin(temp : any){
    this.curLoginInfo = temp;
    localStorage.setItem("token", this.curLoginInfo.access_token);
    window.location.reload();
  }

   catchError(error : any){
    console.log(error);
  }
}
