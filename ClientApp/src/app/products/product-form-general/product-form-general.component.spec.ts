import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductFormGeneralComponent } from './product-form-general.component';

describe('ProductFormGeneralComponent', () => {
  let component: ProductFormGeneralComponent;
  let fixture: ComponentFixture<ProductFormGeneralComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductFormGeneralComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductFormGeneralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
