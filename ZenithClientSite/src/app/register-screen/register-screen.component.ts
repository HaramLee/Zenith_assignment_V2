import { Component, OnInit } from '@angular/core';
import {RegisterUser} from '../register-user';
import {User} from '../user';
import {PostService} from '../post.service';

@Component({
  selector: 'app-register-screen',
  templateUrl: './register-screen.component.html',
  styleUrls: ['./register-screen.component.css']
})
export class RegisterScreenComponent implements OnInit {

 curUser : User;

  constructor(
    private postService: PostService
  ) { }

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
    this.curUser = temp;
    console.log(this.curUser);
  }

   catchError(error : any){
    console.log(error);
  }
}
