import { Component, OnInit } from '@angular/core';
import {User} from '../user';

@Component({
  selector: 'app-loging-screen',
  templateUrl: './loging-screen.component.html',
  styleUrls: ['./loging-screen.component.css']
})
export class LogingScreenComponent implements OnInit {
   userData : User;
  constructor() { }

  ngOnInit() {
  }
  
}
