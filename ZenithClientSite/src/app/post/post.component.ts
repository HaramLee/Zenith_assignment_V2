import { Component, OnInit } from '@angular/core';
import {Post} from '../post';
import {PostService} from '../post.service';
import {Login} from '../login';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  results: Array<Post>;
  userData : Login;

  constructor(private postService: PostService) { }

  ngOnInit() {
    this.postService.getAll().subscribe(
      data => { this.results = data; },
      error => console.log(error)
    );
    this.getLoginToken();
  }

  getLoginToken():void{
    this.postService.userLogin()
    .then(userData => this.userData = userData);
  }
}