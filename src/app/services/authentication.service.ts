import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  currentUser: BehaviorSubject<User | null>;
  constructor() {
    this.currentUser = new BehaviorSubject<User | null>(null);
  }
  logIn(userName: string, pass: string) {
    /// just for testing
    if (userName === 'admin' && pass == 'admin') {
      let receivedUser = new User({
        userName: userName,
        id: 2,
        email: 'admin@admin.com',
      });
      this.currentUser.next(receivedUser);
    }
  }
  logOut() {
    this.currentUser.next(null);
  }
  getCurrUserVal() {
    if (this.currentUser) {
      this.currentUser.value;
    } else {
      null;
    }
  }
}
