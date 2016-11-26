import {Login} from './login';
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

  userLogin(): Promise<Login>{
    var Loginheaders = new Headers({'Content-Type': 'application/x-www-form-urlencoded'});
    var url = `${this.BASE_URL}/connect/token`;
    var body = 'username=a&password=P@$$w0rd&grant_type=password' 
    //'username': 'a', 'password': 'P@$$w0rd', 'grant_type': 'password', 
    return this.http.post(url, body,{headers: Loginheaders})
    .toPromise()
    .then(result => result.json() as Login)
    .catch(this.handleError);
  }
}