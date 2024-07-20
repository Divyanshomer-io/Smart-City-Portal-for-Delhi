import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MetroSchedulesComponent } from './metro-schedules.component';

describe('MetroSchedulesComponent', () => {
  let component: MetroSchedulesComponent;
  let fixture: ComponentFixture<MetroSchedulesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MetroSchedulesComponent]
    });
    fixture = TestBed.createComponent(MetroSchedulesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
