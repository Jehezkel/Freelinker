import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  currentUser: BehaviorSubject<User | null>;
  API_BASE_URL = environment.API_BASE_URL;
  constructor(private msgService: MessageService, private http: HttpClient) {
    this.currentUser = new BehaviorSubject<User | null>(null);
  }
  logIn(userName: string, password: string) {
    const url = `${this.API_BASE_URL}/account/login`;
    console.log('sending query to: ', url);
    this.http.post<User>(url, { userName, password }).subscribe((response) => {
      console.log('received reponse', response);
      this.currentUser.next(response);
    });
  }
  logOut() {
    this.currentUser.next(null);
    this.msgService.newInfo('Logged out');
  }
  getCurrUserVal() {
    if (this.currentUser) {
      this.currentUser.value;
    } else {
      null;
    }
  }
}
