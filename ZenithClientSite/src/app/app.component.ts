import { Component } from '@angular/core';
import { PostService } from "./post.service";
import { PostComponent } from "./post/post.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [PostService]
})
export class AppComponent {
  alive : boolean
  constructor(){
    if(localStorage.getItem("role") == "true"){
      this.alive = false;
    }else{
      this.alive = true;
    }
  }
}