import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-user-button',
  templateUrl: './user-button.component.html',
  styleUrls: ['./user-button.component.scss'],
})
export class UserButtonComponent implements OnInit {
  loginFormGroup: FormGroup;
  menuVisible = false;
  isLoggedIn = false;
  submitted = false;
  user: User | null = null;
  constructor(private authService: AuthenticationService, fb: FormBuilder) {
    this.authService.currentUser.subscribe((u) => {
      this.isLoggedIn = u !== null;
      this.user = u;
    });
    this.loginFormGroup = fb.group({
      login: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
  get LoginFormControl() {
    return this.loginFormGroup.controls;
  }
  ngOnInit(): void {}
  submitLogOut() {
    this.authService.logOut();
    console.log('logging out');
    this.menuVisible = false;
  }
  submitLogIn() {
    this.authService.logIn(
      this.LoginFormControl['login'].value,
      this.LoginFormControl['password'].value
    );
    // this.menuVisible = false;
    this.submitted = true;
  }
}
