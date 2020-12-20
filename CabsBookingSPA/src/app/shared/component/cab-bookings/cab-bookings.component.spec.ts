import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabBookingsComponent } from './cab-bookings.component';

describe('CabBookingsComponent', () => {
  let component: CabBookingsComponent;
  let fixture: ComponentFixture<CabBookingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CabBookingsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CabBookingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
