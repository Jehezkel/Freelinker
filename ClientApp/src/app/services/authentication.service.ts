import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from '../models/user.model';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  currentUser: BehaviorSubject<User | null>;
  constructor(private msgService: MessageService) {
    this.currentUser = new BehaviorSubject<User | null>(null);
  }
  logIn(userName: string, pass: string) {
    /// just for testing
    if (userName === 'admin' && pass == 'admin') {
      let receivedUser = new User({
        username: userName,
        id: 2,
        email: 'admin@admin.com',
      });
      this.currentUser.next(receivedUser);
      this.msgService.newSuccess(`Hello ${receivedUser.username!}`);
    } else {
      this.msgService.newError(
        'Login failed! Login does not exist or incorrect password'
      );
    }
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
