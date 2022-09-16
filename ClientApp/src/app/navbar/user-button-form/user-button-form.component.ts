import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { finalize } from 'rxjs';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-user-button-form',
  templateUrl: './user-button-form.component.html',
  styleUrls: ['./user-button-form.component.scss'],
})
export class UserButtonFormComponent implements OnInit {
  loginFormGroup: FormGroup;
  isLoading: boolean = false;
  @Output() showMenuEvent = new EventEmitter<boolean>();
  constructor(private authService: AuthenticationService, fb: FormBuilder) {
    this.loginFormGroup = fb.group({
      login: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
  get LoginFormControl() {
    return this.loginFormGroup.controls;
  }
  ngOnInit(): void {}
  onSubmit() {
    if (this.isLoading) return;
    this.isLoading = true;
    this.authService
      .logIn(
        this.LoginFormControl['login'].value,
        this.LoginFormControl['password'].value
      )
      .pipe(finalize(() => (this.isLoading = false)))
      .subscribe(() => {
        // this.menuVisible = false;
        this.showMenuEvent.emit(false);
        this.loginFormGroup.reset();
        // this.submitted = false;
      });
    // this.menuVisible = false;
  }
}
