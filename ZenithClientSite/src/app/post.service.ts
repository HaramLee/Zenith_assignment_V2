import {Login} from './login';
import {ZenithEvent} from './zenith-event';
import {RegisterUser} from './register-user';
import {User} from './user';
import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class PostService {
  private BASE_URL = "http://localhost:5000";
  private headers = new Headers({'grant_type': 'password'});

  constructor(private http: Http) { }

  private handleError(error: any): Promise<any> {
      console.error('An error occurred', error); // for demo purposes only
      return Promise.reject(error.message || error);
    }

  getAll() {
    return this.http.get('http://localhost:5000/api/activity')
    .map((res: Response) => res.json());
  }

  userLogin(username : string, password: string): Promise<Login>{
    var Loginheaders = new Headers({'Content-Type': 'application/x-www-form-urlencoded'});
    var url = `${this.BASE_URL}/connect/token`;
    var body = `username=${username}&password=${password}&grant_type=password`;
    //'username': 'a', 'password': 'P@$$w0rd', 'grant_type': 'password', 
    return this.http.post(url, body,{headers: Loginheaders})
    .toPromise()
    .then(result => result.json() as Login)
    .catch(this.handleError);
  }

  getEvents(token: string): Promise<ZenithEvent[]>{
    var eventHeaders = new Headers({'Content-Type': 'application/x-www-form-urlencoded', 'Authorization': `Bearer ${token}`});
    var url = `${this.BASE_URL}/api/event`;
    return this.http.get(url, {headers : eventHeaders})
    .toPromise()
    .then(response =>response.json() as ZenithEvent[])
    .catch(this.handleError);
  }

  userRegister(newUser : RegisterUser):Promise<User>{
    var registerHeaders = new Headers({'Content-Type': 'application/json'});
    var url = `${this.BASE_URL}/api/account`;
    return this.http.post(url, newUser, {headers: registerHeaders})
    .toPromise()
    .then(res => res.json().data)
    .catch(this.handleError);
  }
}