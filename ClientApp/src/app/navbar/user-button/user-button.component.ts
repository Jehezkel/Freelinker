import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { finalize } from 'rxjs';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-user-button',
  templateUrl: './user-button.component.html',
  styleUrls: ['./user-button.component.scss'],
})
export class UserButtonComponent implements OnInit {
  menuVisible = false;
  isLoggedIn = false;
  loading = false;
  user: User | null = null;
  constructor(private authService: AuthenticationService) {
    this.authService.currentUser.subscribe((u) => {
      this.isLoggedIn = u !== null;
      this.user = u;
    });
  }
  ngOnInit(): void {}
  submitLogOut() {
    this.authService.logOut();
    console.log('logging out');
    this.menuVisible = false;
  }
}
