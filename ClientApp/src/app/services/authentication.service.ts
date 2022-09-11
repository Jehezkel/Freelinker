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
  userStorageKey = 'user';
  constructor(private msgService: MessageService, private http: HttpClient) {
    this.currentUser = new BehaviorSubject<User | null>(null);
    this.retriveUserFromStorage();
  }
  retriveUserFromStorage() {
    var cachedUser = sessionStorage.getItem(this.userStorageKey);
    if (cachedUser) {
      this.currentUser.next(JSON.parse(cachedUser));
    }
  }
  logIn(userName: string, password: string) {
    const url = `${this.API_BASE_URL}/account/login`;
    this.http.post<User>(url, { userName, password }).subscribe((response) => {
      sessionStorage.setItem('user', JSON.stringify(response));
      this.currentUser.next(response);
    });
  }
  logOut() {
    this.currentUser.next(null);
    this.msgService.newInfo('Logged out');
    sessionStorage.removeItem(this.userStorageKey);
  }
  getCurrUserVal() {
    if (this.currentUser) {
      this.currentUser.value;
    } else {
      null;
    }
  }
}
