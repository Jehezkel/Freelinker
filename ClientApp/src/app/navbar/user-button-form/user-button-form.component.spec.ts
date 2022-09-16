import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserButtonFormComponent } from './user-button-form.component';

describe('UserButtonFormComponent', () => {
  let component: UserButtonFormComponent;
  let fixture: ComponentFixture<UserButtonFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserButtonFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserButtonFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
