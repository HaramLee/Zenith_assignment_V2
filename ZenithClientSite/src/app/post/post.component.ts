import { Component, OnInit } from '@angular/core';
import {Post} from '../post';
import {PostService} from '../post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  results: Array<Post>;

  constructor(private postService: PostService) { }

  ngOnInit() {
    this.postService.getAll().subscribe(
      data => { this.results = data; },
      error => console.log(error)
    );
  }
}