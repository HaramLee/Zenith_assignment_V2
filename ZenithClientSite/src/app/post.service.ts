import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class PostService {

  constructor(private http: Http) { }

  getAll() {
    return this.http.get('http://localhost:5000/api/activity')
    .map((res: Response) => res.json());
  }
}