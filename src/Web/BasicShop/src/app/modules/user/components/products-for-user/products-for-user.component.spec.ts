import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsForUserComponent } from './products-for-user.component';

describe('ProductsForUserComponent', () => {
  let component: ProductsForUserComponent;
  let fixture: ComponentFixture<ProductsForUserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductsForUserComponent]
    });
    fixture = TestBed.createComponent(ProductsForUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
