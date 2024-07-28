import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Shop } from './shop.component';

describe('ProductsAndCartComponent', () => {
  let component: Shop;
  let fixture: ComponentFixture<Shop>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Shop]
    });
    fixture = TestBed.createComponent(Shop);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
